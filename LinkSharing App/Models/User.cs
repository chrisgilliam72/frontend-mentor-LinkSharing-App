using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LinkSharingRepository.Models;

public class User
{

    public int Id { get; set; }

    public String FirstName { get; set; } = "";
 
    public String Surname { get; set; } = "";
    [Required]
    public String Email { get; set; } = "";
    [Required]
    public String Password { get; set; } = "";

}
