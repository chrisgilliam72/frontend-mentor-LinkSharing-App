namespace LinkSharing_App.ViewModels
{
    public class ProfileImageViewModel
    {
        public String Base64Image {  get; set; }
        public String ImageFormat { get; set; }
        public String ImgSrc => $"data:{ImageFormat};base64," + Base64Image;
    }
}
