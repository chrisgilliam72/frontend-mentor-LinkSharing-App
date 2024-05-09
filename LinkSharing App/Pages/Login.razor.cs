using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace LinkSharing_App.Pages
{
    partial class Login
    {
        [Inject]
        public IUserService UserService { get; set; } 
        public LoginDetails Details { get; set; } = new();

        public async Task OnLogin()
        {
            var user= await UserService.GetAuthenticateUser(Details.Username, Details.Password);
        }
    }
}
