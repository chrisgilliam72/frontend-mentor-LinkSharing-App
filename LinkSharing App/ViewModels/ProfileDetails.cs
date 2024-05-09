namespace LinkSharing_App.ViewModels
{
    public class ProfileDetails
    {
        public String Name { get; set; } = default!;
        public String LastName { get; set; } = default!;    
        public String EmailAddress { get; set; } = default!;

        public String Photo { get; set; } = default!;

        public String ImgSrc => String.IsNullOrEmpty(Photo) ?"" : $"data:{PhotoFormat};base64," + Photo;
        public String ImgStyle => $"background-image:url('{ImgSrc}');background-size:100%;";
        public String PhotoFormat { get; set; } = default!;

        public bool HasPhoto => !String.IsNullOrEmpty(Photo);   
    }
}
