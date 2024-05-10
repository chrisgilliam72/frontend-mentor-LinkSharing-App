using LinkSharingRepository.Models;
using System.Net.Http.Json;
namespace LinkSharing_App.Services;

public class CustomLinkService(HttpClient httpClient) : ICustomLinkService
{
    public async Task<IEnumerable<CustomLink>> GetCustomLinks(int userId)
    {
        var links = await httpClient.GetFromJsonAsync<List<CustomLink>>($"platforms/{userId}");
        return links;
    }

    public async Task<CustomLink> AddCustomLink(int platformId, int userId, string linkURL)
    {
        CustomLink customLink = null;
        try
        {
            var response = await httpClient.PostAsJsonAsync("/customlinks/add", new { platformId=platformId,userId=userId,linkUrl=linkURL});
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                customLink = await response.Content.ReadFromJsonAsync<CustomLink>();
            }

        }
        catch (Exception)
        {

        }

        return customLink;
    }



    public async Task<bool> RemoveCustomLink(int linkId)
    {
        var response = await httpClient.DeleteAsync("/customlinks/delete/{linkId}");
        return (response != null && response.StatusCode == System.Net.HttpStatusCode.OK);
    }

    public Task<CustomLink> UpdateCustomLink(int linkId, string linkURL)
    {
        throw new NotImplementedException();
    }
}
