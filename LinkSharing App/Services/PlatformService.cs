using LinkSharingRepository.Models;
using System.Net.Http.Json;

namespace LinkSharing_App.Services
{
    public class PlatformService(HttpClient httpClient) : IPlatformService
    {
        public async  Task<IEnumerable<Platform>> GetPlatforms()
        {

            var platforms = await httpClient.GetFromJsonAsync<List<Platform>>("platforms/");
            platforms.ForEach(x => x.Icon = @"/img/" + x.Icon);
            return platforms;
        }


    }
}
