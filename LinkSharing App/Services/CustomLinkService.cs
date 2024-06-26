﻿using LinkSharingRepository.Models;
using System.Net.Http.Json;
namespace LinkSharing_App.Services;

public class CustomLinkService(HttpClient httpClient) : ICustomLinkService
{
    public async Task<IEnumerable<CustomLink>> GetCustomLinks(int userId)
    {
        List<CustomLink>? customLinks = null;
        try
        {
            var response = await httpClient.GetAsync($"/customlinks/{userId}");
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                customLinks = await response.Content.ReadFromJsonAsync<List<CustomLink>>();
                
            }
               
        }
        catch (Exception ex)
        {
            customLinks = new();
        }

        return customLinks!;
    }

    public async Task<CustomLink> AddCustomLink(int platformId, int userId, string linkURL, int displayIndex)
    {
        CustomLink? customLink = null;
        try
        {
            var response = await httpClient.PostAsJsonAsync("/customlinks/add", new { platformId=platformId,userId=userId,linkUrl=linkURL, displayIndex=displayIndex});
            if (response != null && response.Content!=null && response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                customLink = await response.Content.ReadFromJsonAsync<CustomLink>();
            }

        }
        catch (Exception)
        {

        }

        return customLink!;
    }



    public async Task<bool> RemoveCustomLink(int linkId)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"/customlinks/delete/{linkId}");
            return (response != null && response.StatusCode != System.Net.HttpStatusCode.NotFound);
        }
        catch 
        {
            
            return false; 
        }
    }

    public async Task<CustomLink> UpdateCustomLink(int linkId, string linkURL,int displayIndex)
    {
        CustomLink updatedLink = null;
        try
        {
            
            var response = await httpClient.PutAsJsonAsync($"/customlinks/update/{linkId}", new {linkURL=linkURL, displayIndex=displayIndex});
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                updatedLink = await response.Content.ReadFromJsonAsync<CustomLink>();
            }
        }
        catch (Exception)
        {

           return null;
        }
        return updatedLink;
    }
}
