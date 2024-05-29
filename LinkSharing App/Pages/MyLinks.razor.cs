using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using LinkSharingRepository.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LinkSharing_App.Pages;

partial class MyLinks
{
    [Parameter]
    public String ImageSrc { get; set; } = default!;

    [Parameter]
    public String FirstName { get; set; } = default!;
    [Parameter] public String LastName { get; set; } = default!;

    [Parameter]
    public String Email { get; set; }= default!;

    [Parameter]
    public List<String> Links { get; set; } = new();

    [Parameter]
    public CustomizeLinksViewModel CustomLinks { get; set; } = null!;
    [Inject]
    public IJSRuntime JSRuntime { get; set; }


    protected override void OnInitialized()
    {
        
        base.OnInitialized();
    }

    public async Task  OnGotoLink(String platformURL)
    {
        await JSRuntime.InvokeVoidAsync("openInNewTab", "https://"+platformURL);
    }
}
