using LinkSharingRepository.Models;
using System.ComponentModel.DataAnnotations;

namespace LinkSharing_App.ViewModels;

public class CustomizedLink
{
    public int Id { get; set; }
    [Required]
    public String LinkUrl { get; set; } = default!;
    [Required]
    public Platform Platform { get; set; }
    public String SelectedPlatformName => Platform?.Name ?? "Select platform";

    public int DisplayIndex { get; set; }

    public String HTMLId => "platformSelection" + DisplayIndex;


}
