using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace LinkSharing_App.Pages
{
    partial class MobilePreview
    {
        [Parameter]
        public String UserId { get; set; } = "";
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public ICustomLinkService CustomLinkService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        public ViewModels.ProfileDetails ProfileDetailsViewModel { get; set; } = new();
        public CustomizeLinksViewModel? CustomizeLinksViewModel { get; set; } =  null;

        protected override async Task OnInitializedAsync()
        {
            int userId = Convert.ToInt32(UserId);


            var user = await UserService.GetUser(userId);
            if (user != null)
            {
                ProfileDetailsViewModel.Id = user.Id;
                ProfileDetailsViewModel.Name = user.FirstName;
                ProfileDetailsViewModel.LastName = user.Surname;
                ProfileDetailsViewModel.EmailAddress = user.Email;
                ProfileDetailsViewModel.Photo = user.Photo;
                ProfileDetailsViewModel.PhotoFormat = user.PhotoFormat;
            }
            var listLinks = (await CustomLinkService.GetCustomLinks(userId)).ToList();
            CustomizeLinksViewModel = new CustomizeLinksViewModel(listLinks);
        }

        public void OnCopyLink()
        {

        }

        public void OnBack()
        {
            NavigationManager.NavigateTo($"/TabbedView/{UserId}", true);
        }
    }
}
