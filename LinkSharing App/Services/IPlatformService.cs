using LinkSharingRepository.Models;

namespace LinkSharing_App.Services
{
    public interface IPlatformService
    {
        public IEnumerable<Platform> GetPlatforms();
    }
}
