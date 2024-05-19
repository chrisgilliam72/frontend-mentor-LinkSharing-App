using LinkSharingRepository.Models;
namespace LinkSharing_App.Services;

public interface ICustomLinkService
{
    public Task<IEnumerable<CustomLink>> GetCustomLinks(int userId);
    public Task<CustomLink> AddCustomLink(int platformId, int userId, string linkURL, int displayIndex);
    public Task <bool> RemoveCustomLink(int linkId);
    public Task<CustomLink> UpdateCustomLink(int linkId, string linkURL, int displayIndex);
}
