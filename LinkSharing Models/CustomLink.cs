using System.ComponentModel.DataAnnotations;

namespace LinkSharingRepository.Models;

public class CustomLink
{
    [Key]
    public int Id { get; set; }

    public String URL { get; set; } = default!;

    public Platform Platform { get; set; } = default!;
    public User User { get; set; } = default!;
    public int DisplayIndex { get; set; } = default!;   

}
