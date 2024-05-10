using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using LinkSharingRepository.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LinkSharing_App.Pages
{
    partial class ProfileDetails
    {
        [Parameter]
        public int UserId { get; set; }
        [Parameter]
        public EventCallback<ViewModels.ProfileDetails> ProfileDetailsUpdated { get; set; }
        [Inject]
        public IUserService UserService { get; set; }
        public ViewModels.ProfileDetails ProfileDetailsViewModel { get; set; } = new ();
        private String _photoString = default!;
        private String _photoFormat = default!;
        private byte[] _photoBytes = null!;

        protected override async Task OnInitializedAsync()
        {
            var user= await UserService.GetUser(UserId);
            if (user != null) 
            {
                ProfileDetailsViewModel.Id = user.Id;
                ProfileDetailsViewModel.Name = user.FirstName;
                ProfileDetailsViewModel.LastName = user.Surname;
                ProfileDetailsViewModel.EmailAddress = user.Email;
                ProfileDetailsViewModel.Photo = user.Photo;
                ProfileDetailsViewModel.PhotoFormat=user.PhotoFormat;
            }
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
            User user = new()
            {
                Id= ProfileDetailsViewModel.Id,
                FirstName = ProfileDetailsViewModel.Name,
                Surname = ProfileDetailsViewModel.LastName,
                Email = ProfileDetailsViewModel.EmailAddress,
                Photo = ProfileDetailsViewModel.Photo,
                PhotoFormat = ProfileDetailsViewModel.PhotoFormat
            };
            user = await UserService.UpdateUser(user);
            await ProfileDetailsUpdated.InvokeAsync(ProfileDetailsViewModel);
        }
        public void OnPhotoSubmit()
        {
            ProfileDetailsViewModel.Photo = _photoString;
            ProfileDetailsViewModel.PhotoFormat = _photoFormat;
        }
    }
}
