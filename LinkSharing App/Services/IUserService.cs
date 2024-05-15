using LinkSharing_App.Models;
using LinkSharingRepository.Models;

namespace LinkSharing_App.Services
{
    public interface IUserService
    {
        public Task<User> GetUser(int userId);
        public Task<UserAuthDetailsResponse> LoginUser(String userName, String userPassword);
        public Task<User> CreateUser(String  userName, String password);
        public Task<User> UpdateUser(User user);
        public Task<User> GetAuthenticatedUser(string jwToken);
    }
}
