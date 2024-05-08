using LinkSharingRepository.Interfaces;
using LinkSharingRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkSharingRepository.Services;

public class LinkSharingSQLiteRepository  : ILinkSharingRepository
{
    private readonly SQLiteContext _context;
    public LinkSharingSQLiteRepository(SQLiteContext context)
    {
        _context=context;
    }

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
        var dbPlatfrm= await _context.Platforms.FirstAsync(x=>x.Id==platform.Id);
        if (dbPlatfrm!=null) 
        {
            dbPlatfrm.BrandingColor = platform.BrandingColor;
            dbPlatfrm.Name = platform.Name;
            dbPlatfrm.Icon = platform.Icon;
            await _context.SaveChangesAsync();
        }

        return platform;
    }

    public async Task<CustomLink> CreateCustomLink(Platform platform, User user, string url)
    {
        CustomLink customLink = new()
        {
            User = user,
            Platform = platform,
            URL = url
        };

        await _context.CustomLinks.AddAsync(customLink);
        await _context.SaveChangesAsync();
        return customLink;
    }

    public async Task<bool> RemoveCustomLink(int customLinkId)
    {
        var query = _context.CustomLinks.Where(x=>x.Id == customLinkId);
        _context.RemoveRange(query);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<CustomLink>> GetCustomLinks(User user)
    {
      return await _context.CustomLinks.Where(x => x.User == user).ToListAsync();
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
                Password = password
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
    public async Task<User?> GetAuthenticatedUser(String email, String password)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }

    public async Task<bool> RemoveUser(String email, String password)
    {
        var user = await GetAuthenticatedUser(email, password);
        if (user != null)
        {
             _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
