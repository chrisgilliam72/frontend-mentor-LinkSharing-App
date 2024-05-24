using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using LinkSharingRepository.Models;
using Microsoft.AspNetCore.Components;

namespace LinkSharing_App.Pages
{
    partial class PublicProfileLinks
    {
        [Parameter]
        public String UserId { get; set; } = "";
        [Inject]
        ICustomLinkService customLinkService { get; set; }
        [Inject]
        IUserService userService { get; set; }

        public LinkSharing_App.ViewModels.ProfileDetails ProfileDetails { get; set; } = new();

        public CustomizeLinksViewModel? CustomizedLinks = null;

        protected override async Task OnInitializedAsync()
        {
            int userId = 0;

            if (Int32.TryParse(UserId,out userId))
            {
                var currentUser = await userService.GetUser(userId);
                if (currentUser is not null)
                {
                    ProfileDetails.EmailAddress = currentUser.Email;
                    ProfileDetails.Name = currentUser.FirstName;
                    ProfileDetails.LastName = currentUser.Surname;
                    ProfileDetails.Photo = currentUser.Photo;
                    ProfileDetails.PhotoFormat = currentUser.PhotoFormat;
                    var customLinks = await customLinkService.GetCustomLinks(userId);
                    CustomizedLinks = new CustomizeLinksViewModel(customLinks);

                }

            }

        }
    }
}
