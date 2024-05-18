using LinkSharingRepository.Models;

namespace LinkSharing_App.ViewModels;

public class CustomizedLink
{
    public int Id { get; set; }
    public String LinkUrl { get; set; } = default!;
    public Platform Platform { get; set; }
    public String SelectedPlatformName => Platform?.Name ?? "Select platform";

    public int DisplayIndex { get; set; }

    public String HTMLId => "platformSelection" + DisplayIndex;


}
