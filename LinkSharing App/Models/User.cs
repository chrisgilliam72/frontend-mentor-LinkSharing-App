using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LinkSharingRepository.Models;

public class User
{
    [JsonIgnore]
    public int Id { get; set; }

    public String FirstName { get; set; } = default!;
 
    public String Surname { get; set; } = default!;
    [Required]
    public String Email { get; set; } = default!;
    [Required]
    public String Password { get; set; } = default!;

}
