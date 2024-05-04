using LinkSharingRepository.Models;

namespace LinkSharingRepository.Interfaces;

public interface ILinkSharingRepository
{
    public  Task<IEnumerable<Platform>> GetPlatforms();
    public Task<CustomLink> CreateCustomLink(Platform platform, User user, string url);
    public Task<bool> RemoveCustomLink(int customLinkId);
    public Task<IEnumerable<CustomLink>> GetCustomLinks(User user);
    public Task<User?> CreateUser(string firstName, string lastName, string email, string password);
    public Task<User?> GetUser(string firstName, string lastName, string email);
    public Task<User?> GetAuthenticatedUser(string email, string password);
    public Task<bool> RemoveUser(string email, string password);
}
