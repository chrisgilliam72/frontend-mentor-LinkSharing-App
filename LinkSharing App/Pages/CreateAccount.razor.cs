using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace LinkSharing_App.Pages
{

    partial class CreateAccount
    {
        [Inject]
        public IUserService UserService { get; set; }
        public RegisterUser RegisterUser { get; set; } = new();

        public async Task OnCreateAccount()
        {
            await UserService.CreateUser(RegisterUser.Email, RegisterUser.Password);
        }

    }
}
