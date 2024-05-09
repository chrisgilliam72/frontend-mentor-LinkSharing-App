using LinkSharingRepository.Models;

namespace LinkSharing_App.Services
{
    public interface IUserService
    {
        public Task<User> CreateUser(String  userName, String password);
    }
}
