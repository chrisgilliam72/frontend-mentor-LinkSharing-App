using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components.Forms;

namespace LinkSharing_App.Pages
{
    partial class ProfileDetails
    {
        public ProfileDetailsViewModel ProfilePhotoViewModel { get; set; } = new ();
        private String _photoString = default!;
        private String _photoFormat = default!;
        private byte[] _photoBytes = null!;
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

        public void OnSubmit()
        {
            ProfilePhotoViewModel.Photo = _photoString;
            ProfilePhotoViewModel.PhotoFormat = _photoFormat;
        }
    }
}
