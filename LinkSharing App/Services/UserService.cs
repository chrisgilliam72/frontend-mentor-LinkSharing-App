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
                Email = userName,
                Id = -1
            };
            try
            {
                var response = await httpClient.PostAsJsonAsync("/users/add", user);
                if (response != null && response.StatusCode==System.Net.HttpStatusCode.OK) 
                {
                    user = await response.Content.ReadFromJsonAsync<User>();
                }
               
            }
            catch (Exception ex)
            {

            }
    
            return user;
        }
    }
}
