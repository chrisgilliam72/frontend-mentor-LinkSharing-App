using LinkSharingRepository.Models;

namespace LinkSharing_App.ViewModels;

public class CustomizeLinks
{
    public List<CustomizedLink> CustomLinks { get; } = new();
    public CustomizeLinks(IEnumerable<CustomLink> customLinks)
    {
        foreach (var link in customLinks)
        {
            CustomizedLink customizedLink = new()
            {
                Id = link.Id,
                Platform = link.Platform,
                LinkUrl = link.URL
            };
           CustomLinks.Add(customizedLink);
        }
    }
}
