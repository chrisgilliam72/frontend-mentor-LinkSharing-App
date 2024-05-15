using LinkSharing_App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace LinkSharing_App
{
    public class CustomAuthenticationStateProvider(IUserService userService) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var tokenValue = await storageService.Read("authtoken");
            //var user = await userService.GetAuthenticatedUser(tokenValue);
            //if (user !=null)
            //{
            //    var claim = new Claim(ClaimTypes.Name, user.Email);
            //    var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
            //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            //    return new AuthenticationState(claimsPrincipal);
            //}

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
