using System.ComponentModel.DataAnnotations;

namespace LinkSharing_App.ViewModels
{
    public class ProfileDetails
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; } = default!;
        [Required]
        public String LastName { get; set; } = default!;
        public String EmailAddress { get; set; } = default!;

        public String Photo { get; set; } = default!;

        public String ImgSrc => String.IsNullOrEmpty(Photo) ?"" : $"data:{PhotoFormat};base64," + Photo;
        public String ImgStyle => $"background-image:url('{ImgSrc}');background-repeat: no-repeat;  background-size:cover; background-position: center center;";
        public String PhotoFormat { get; set; } = default!;

        public bool HasPhoto => !String.IsNullOrEmpty(Photo);   

        public String PublicURL { get; set; } = "";
    }
}
