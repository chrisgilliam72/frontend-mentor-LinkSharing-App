namespace LinkSharing_App.ViewModels;

public class CustomizedLinkViewModel
{
 
    public String PlatformName { get; set; }
    public String LinkUrl { get; set; }
    public LinkPlatformViewModel Platform { get; set; }
    public String SelectedPlatformName => Platform?.Name ?? "Select platform";

    public int PlatformLinkId => Platform?.Id ?? 0;
}
