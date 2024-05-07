using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LinkSharing_App.Pages
{
    partial class ProfileDetails
    {
        [Parameter]
        public EventCallback<ProfileDetailsViewModel> ProfileDetailsUpdated { get; set; }
        public ProfileDetailsViewModel ProfileDetailsViewModel { get; set; } = new ();
        private String _photoString = default!;
        private String _photoFormat = default!;
        private byte[] _photoBytes = null!;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
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

        public async void OnSave()
        {
            await ProfileDetailsUpdated.InvokeAsync(ProfileDetailsViewModel);
        }
        public void OnPhotoSubmit()
        {
            ProfileDetailsViewModel.Photo = _photoString;
            ProfileDetailsViewModel.PhotoFormat = _photoFormat;
        }
    }
}
