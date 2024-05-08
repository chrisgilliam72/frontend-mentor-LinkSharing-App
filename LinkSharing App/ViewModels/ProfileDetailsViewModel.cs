namespace LinkSharing_App.ViewModels
{
    public class ProfileDetailsViewModel
    {
        public String Name { get; set; }
        public String LastName { get; set; }
        public String EmailAddress { get; set; }

        public String Photo {  get; set; }

        public String ImgSrc => String.IsNullOrEmpty(Photo) ?"" : $"data:{PhotoFormat};base64," + Photo;
        public String ImgStyle => $"background-image:url('{ImgSrc}');background-size:100%;";
        public String PhotoFormat { get; set; }

        public bool HasPhoto => !String.IsNullOrEmpty(Photo);   
    }
}
