using System.ComponentModel.DataAnnotations;

namespace LinkSharingRepository.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public String FirstName { get; set; } = "";
    [Required]
    public String Surname { get; set; } = "";
    [Required]
    public String Email { get; set; } = "";
    [Required]
    public String Password { get; set; } = "";

    public String Photo { get; set; } = default!;
    public String PhotoFormat { get; set; } = "";

}
