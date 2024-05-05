using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components.Forms;

namespace LinkSharing_App.Pages
{
    partial class ProfileDetails
    {
        public ProfileDetailsViewModel ProfilePhotoViewModel { get; set; } = new ();
        private String _photoString;
        private String _photoFormat;
        private byte[] _photoBytes;
        public async void OnPhotoUploaded(InputFileChangeEventArgs e)
        {
            if (e.File!=null)
            {
                using var memoryStream = new MemoryStream();
                await (e.File.OpenReadStream().CopyToAsync(memoryStream));
                _photoBytes = memoryStream.ToArray();
                _photoString = Convert.ToBase64String(_photoBytes);
                _photoFormat = e.File.ContentType;
            }
         
        }

    }
}
