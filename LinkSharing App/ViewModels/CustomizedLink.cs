using LinkSharingRepository.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinkSharing_App.ViewModels;

public class CustomLinkViewModel
{
    public int Id { get; set; }
    public String LinkUrl { get; set; } = " ";

    public int PlatformId { get; set; }
    public String PlatformName { get; set; } = "";
    public String PlatformURL { get; set; } = "";
    public String PlatformIconPath { get; set; } = "";
    public String WhitePlatformIconPath => PlatformIconPath.Contains("-white.") ? PlatformIconPath : PlatformIconPath.Replace(".", "-white.");
    public string PlatformBrandingColor { get; set; } = "";
    public String SelectedPlatformName => PlatformName!=null ? PlatformName : "Select platform";

    public int DisplayIndex { get; set; }

    public String HTMLId => "platformSelection" + DisplayIndex;


}
