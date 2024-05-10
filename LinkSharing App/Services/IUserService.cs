using LinkSharingRepository.Models;

namespace LinkSharing_App.Services
{
    public interface IUserService
    {
        public Task<User> GetUser(int userId);
        public Task<User?> GetAuthenticateUser(String userName, String password);
        public Task<User> CreateUser(String  userName, String password);
        public Task<User> UpdateUser(User user);
    }
}
