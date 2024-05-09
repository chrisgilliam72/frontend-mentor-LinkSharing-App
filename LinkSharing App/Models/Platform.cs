using System.ComponentModel.DataAnnotations;

namespace LinkSharingRepository.Models;

public class Platform
{

    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public String Icon { get; set; } = default!;
    public String BrandingColor { get; set; } = default!;

    public String IconPath => @"/img/" + Icon;
}
