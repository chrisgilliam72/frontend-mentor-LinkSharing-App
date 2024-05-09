using System.ComponentModel.DataAnnotations;

namespace LinkSharing_App.ViewModels
{
    public class RegisterUser
    {

        [Required]
        [EmailAddress]
        public String Email { get; set; } = default!;
        [Required]
        [MinLength(8)]
        public String Password { get; set; } = default!;
        [Required]
        [Compare("Password")]
        [MinLength(8)]
        public String PasswordConfirm { get; set; } = default!;
    }
}
