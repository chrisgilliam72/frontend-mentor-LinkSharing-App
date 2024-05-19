using LinkSharingRepository.Interfaces;
using LinkSharingRepository.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace LinkSharingRepository.Services;

public class LinkSharingSQLiteRepository(SQLiteContext _context)  : ILinkSharingRepository
{

    public async Task<IEnumerable<Platform>> GetPlatforms()
    {
        return await _context.Platforms.ToListAsync();
    }
    public async Task<Platform> AddPlatform(Platform platform)
    {
        await _context.Platforms.AddAsync(platform);
        await _context.SaveChangesAsync();
        return platform;
    }
    public async Task<Platform> UpdatePlatform(Platform platform)
    {
        var dbPlatfrm= await _context.Platforms.FirstOrDefaultAsync(x=>x.Id==platform.Id);
        if (dbPlatfrm!=null) 
        {
            dbPlatfrm.BrandingColor = platform.BrandingColor;
            dbPlatfrm.Name = platform.Name;
            dbPlatfrm.Icon = platform.Icon;
            await _context.SaveChangesAsync();
        }

        return platform;
    }
    public async Task<CustomLink> UpdateCustomLink(int customLinkId, string customLinkUrl, int displayIndex)
    {
        var dbCustomLink= await _context.CustomLinks.Include(x=>x.Platform)
                                                    .Include(x=>x.User)
                                                    .FirstOrDefaultAsync(x=>x.Id == customLinkId);
        if (dbCustomLink!=null)
        {
            dbCustomLink.URL = customLinkUrl;
            dbCustomLink.DisplayIndex = displayIndex;
            await _context.SaveChangesAsync();
        }
        return dbCustomLink!;
    }
    public async Task<CustomLink?> CreateCustomLink(int platformId, int userId, string url, int displayIndex)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        var platform = await _context.Platforms.FirstOrDefaultAsync(x => x.Id == platformId);
        if (user != null && platform!=null) 
        {
            CustomLink customLink = new()
            {
                User = user,
                Platform = platform,
                URL = url,
                DisplayIndex = displayIndex
            };

            await _context.CustomLinks.AddAsync(customLink);
            await _context.SaveChangesAsync();
            return customLink;
        }

        return null;
    }

    public async Task<bool> RemoveCustomLink(int customLinkId)
    {
        var query = _context.CustomLinks.Where(x=>x.Id == customLinkId);
        _context.RemoveRange(query);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<CustomLink>> GetCustomLinks(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        return user!=null ? await _context.CustomLinks.Include(x=>x.Platform).Where(x => x.User == user).ToListAsync() : new List<CustomLink>();
    }

    public async Task<User?> CreateUser(String firstName, String lastName, String email, string password)
    {
        if (await GetUser(firstName, lastName, email) == null)
        {


            User user = new User()
            {
                FirstName = firstName,
                Surname = lastName,
                Email = email,
                Password = password,
                Photo="",
                PhotoFormat="",
                PublicURl= await GeneratePublicUrl(firstName, lastName)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();    
            return user;
        }
;       return null;
    }
    public async Task<User?> GetUser(String firstName, String lastName, String email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.FirstName == firstName && x.Surname == lastName && x.Email == email);
    }
    public async Task<User?> GetUser(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x=>x.Email == email);
    }
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUser(int userId)
    {
        return  await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<User?> GetAuthenticatedUser(String email, String password)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }

    public async Task<User?> UpdateUser(int userId, string firstName, string lastName, string email, string photo, string photoFormat)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user != null)
        {
            user.FirstName = firstName;
            user.Surname = lastName;
            user.Email = email;
            user.Photo = photo; 
            user.PhotoFormat = photoFormat;
            await _context.SaveChangesAsync();
        }

        return user;
    }

    public async Task<bool> RemoveUser(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user != null)
        {
             var userLinks=await _context.CustomLinks.Where(x => x.User.Id == userId).ToListAsync();
            _context.CustomLinks.RemoveRange(userLinks);
            await _context.SaveChangesAsync();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<PublicProfile> GetPublicProfile(string publicUrl)
    {
        var user = _context.Users.FirstOrDefault(u => u.PublicURl == publicUrl);
        if (user != null)
        {
            var customLinks = _context.CustomLinks.Where(x => x.User.Id == user.Id).Select(x=>x.URL).ToList();
            PublicProfile publicProfile = new()
            {
                Name = $"{user.FirstName} {user.Surname}",
                Email = user.Email,
                PublicUrl = user.PublicURl,
                CustomLinks = customLinks

            };
            return publicProfile;   
        }

        return null;
    }

    private async Task<String> GeneratePublicUrl(String firstname, string lastname)
    {
        Random random = new Random();
        string publicLinkUrl = "";
        do
        {
            var rnd = random.Next(100000, 200000);
            publicLinkUrl = $"{firstname}.{lastname}{rnd.ToString()}";
        } while (await _context.Users.FirstOrDefaultAsync(x => x.PublicURl == publicLinkUrl) != null);
        return publicLinkUrl;

    }
}
