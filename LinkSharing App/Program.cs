using LinkSharing_App;
using LinkSharing_App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

const string baseAddress = @"https://cg-frontendmentor-link-sharing.azurewebsites.net/";
//const string baseAddress = @" http://localhost:5095/";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});
builder.Services.AddHttpClient<IPlatformService, PlatformService>(client =>
{
    client.BaseAddress= new Uri(baseAddress);
});
builder.Services.AddHttpClient<ICustomLinkService, CustomLinkService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});
await builder.Build().RunAsync();
