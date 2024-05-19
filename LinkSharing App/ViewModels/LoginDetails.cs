using System.ComponentModel.DataAnnotations;

namespace LinkSharing_App.ViewModels
{
    public class LoginDetails
    {
        [Required]
        public String Username { get; set; } = "";
        [Required]
        public String Password { get; set; } = "";


    }
}
