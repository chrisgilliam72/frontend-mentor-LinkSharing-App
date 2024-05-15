using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace LinkSharing_App.Pages
{
    partial class Login
    {
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IlocalStorageService StorageService { get; set; }
        public LoginDetails Details { get; set; } = new();

        public async Task OnLogin()
        {
            var authResult= await UserService.LoginUser(Details.Username, Details.Password);
            if (authResult != null && authResult.user!=null)
            {
                await StorageService.Write("authtoken", authResult.jwtoken);
                NavigationManager.NavigateTo($"/TabbedView/{authResult.user.Id}");
          
             }
        }
    }
}
