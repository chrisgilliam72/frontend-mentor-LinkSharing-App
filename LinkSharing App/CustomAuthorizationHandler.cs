using LinkSharing_App.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;


namespace LinkSharing_App
{
    public class CustomAuthorizationHandler(IlocalStorageService storageService) : DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //getting token from the localstorage
            var tokenValue = await storageService.Read("authtoken");

            //adding the token in authorization header
            if (tokenValue != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenValue);
            
            //sending the request
            return await base.SendAsync(request, cancellationToken);
        }
    }
}