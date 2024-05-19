using LinkSharingRepository.Models;

namespace LinkSharingRepository.Interfaces;

public interface ILinkSharingRepository
{
    public  Task<IEnumerable<Platform>> GetPlatforms();
    public Task<Platform> AddPlatform(Platform platform);
    public Task<Platform> UpdatePlatform(Platform platform);
    public Task<CustomLink?> CreateCustomLink(int platformId, int userId, string url, int displayIndex);
    public Task<bool> RemoveCustomLink(int customLinkId);
    public Task<IEnumerable<CustomLink>> GetCustomLinks(int userId);
    public Task<CustomLink> UpdateCustomLink(int customLinkId, string customLinkUrl, int displayIndex);
    public Task<User?> CreateUser(string firstName, string lastName, string email, string password);

    public Task<User?> UpdateUser(int userId,string firstName, string lastName, string email, string photo, string photoFormat);
    public Task<User?> GetUser(int userId);
    public Task<User?> GetUser(string email);
    public Task<User?> GetUser(string firstName, string lastName, string email);
    public Task<PublicProfile> GetPublicProfile(string publicUrl);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task<User?> GetAuthenticatedUser(string email, string password);
    public Task<bool> RemoveUser(int userId);
}
