using LinkSharingRepository.Models;

namespace LinkSharing_App.ViewModels;

public class CustomizedLinkViewModel
{
 
    public String LinkUrl { get; set; }
    public Platform Platform { get; set; }
    public String SelectedPlatformName => Platform?.Name ?? "Select platform";

    public int PlatformLinkId => Platform?.Id ?? 0;
}
