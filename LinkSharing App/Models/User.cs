using System.ComponentModel.DataAnnotations;

namespace LinkSharingRepository.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public String FirstName { get; set; } = default!;
    [Required]
    public String Surname { get; set; } = default!;
    [Required]
    public String Email { get; set; } = default!;
    [Required]
    public String Password { get; set; } = default;

}
