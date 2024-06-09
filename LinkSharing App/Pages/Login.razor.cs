using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Xml.Linq;

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

        public bool HasErrors = false;
        public bool LoginSuccessful { get; set; } = true;
        public String EmailPlaceHolderText { get; set; } = "name@example.com";
        public String PasswordPlaceHolderText = "";
        public async Task OnLogin()
        {
            HasErrors = false;
            var authResult= await UserService.LoginUser(Details.Username, Details.Password);
            if (authResult != null && authResult.user!=null)
            {
                await StorageService.Write("authtoken", authResult.jwtoken);
                NavigationManager.NavigateTo($"TabbedView/{authResult.user.Id}", true);
          
             }
            else
            {
                LoginSuccessful = false;
                EmailPlaceHolderText = "name@example.com";
            }

        }

        public void OnErrors()
        {
            LoginSuccessful = true;
            EmailPlaceHolderText = "Please enter your email";
            PasswordPlaceHolderText = "Please enter your password";
        }
    }
}
