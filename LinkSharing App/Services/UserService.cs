using LinkSharingRepository.Models;
using System.Net.Http.Json;

namespace LinkSharing_App.Services
{
    public class UserService(HttpClient httpClient) : IUserService
    {


        public async Task<User> CreateUser(string userName, string password)
        {
            User user = new()
            {
                Password = password,
                Email = userName
            };
            var response = await httpClient.PostAsJsonAsync<User>("/users/add", user);
            return user;
        }
    }
}
