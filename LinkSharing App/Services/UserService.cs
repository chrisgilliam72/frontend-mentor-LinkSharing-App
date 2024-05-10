using LinkSharingRepository.Models;
using System.Net.Http.Json;

namespace LinkSharing_App.Services;

public class UserService(HttpClient httpClient) : IUserService
{
    public async Task<User> GetUser(int userId)
    {
        User user = null;
        try
        {

            user =  await httpClient.GetFromJsonAsync<User?>($"/users/user/{userId}");


        }
        catch (Exception ex)
        {

        }

        return user;
    }

    public async Task<User?> GetAuthenticateUser(String userName, String password)
    {
        User user = null;
        try
        {

            user = await httpClient.GetFromJsonAsync<User?>($"/users/getauthenticateduser?username={userName}&password={password}");
         

        }
        catch (Exception ex)
        {

        }

        return user;
    }

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
