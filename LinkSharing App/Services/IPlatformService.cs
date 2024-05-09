using LinkSharingRepository.Models;

namespace LinkSharing_App.Services
{
    public interface IPlatformService
    {
        public Task<IEnumerable<Platform>> GetPlatforms();
    }
}
