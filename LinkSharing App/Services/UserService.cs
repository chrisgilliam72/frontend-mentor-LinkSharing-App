using LinkSharing_App.Models;
using LinkSharingRepository.Models;
using System.Net.Http.Json;

namespace LinkSharing_App.Services;

public class UserService(HttpClient httpClient) : IUserService
{


    public async Task<User> UpdateUser(User user)
    {
        User? updatedUser = null;
        try
        {
            var response = await httpClient.PutAsJsonAsync("/users/update", user);
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                updatedUser = await response.Content.ReadFromJsonAsync<User>();
            }

        }
        catch (Exception ex)
        {

        }

        return updatedUser!;

     
    }

    public async Task<User> GetUser(int userId)
    {
        User? user = null;
        try
        {

            user =  await httpClient.GetFromJsonAsync<User?>($"/users/user/{userId}");


        }
        catch (Exception ex)
        {

        }

        return user!;
    }

    public async Task<UserAuthDetailsResponse> LoginUser(String userName, String userPassword)
    {

        try
        {

            var response = await httpClient.PostAsJsonAsync($"/users/login",new {username=userName,password= userPassword });
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var token = (await response.Content.ReadFromJsonAsync<UserAuthDetailsResponse>());
                return token;
            }


        }
        catch (Exception ex)
        {

        }

        return null;
    }

    public async Task<User> CreateUser(string userName, string password)
    {
        User? user = new()
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

        return user!;
    }

    public async Task<User> GetAuthenticatedUser(string jwToken)
    {
        User? user = null;
        try
        {

            var response = await httpClient.PostAsJsonAsync("/users/getauthenticateduser",new {jwtoken= jwToken });
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                user = await response.Content.ReadFromJsonAsync<User>();
            }
               

        }
        catch (Exception)
        {

            throw;
        }

        return user!;
    }
}
