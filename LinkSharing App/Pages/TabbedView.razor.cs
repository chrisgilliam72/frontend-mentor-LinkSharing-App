using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace LinkSharing_App.Pages;

partial class TabbedView
{
    [Inject]
    public IPlatformService PlatformService { get; set; }

    [Parameter]
    public int UserId { get; set; }
    public CustomizeLinks CustomizeLinksViewModel { get; set; } = new();
    public ViewModels.ProfileDetails ProfileDetailsViewModel { get; set; } =  new ();
    public bool ShowProfileDetails { get; set; }
    public bool ShowCustomLinks {  get; set; }

    protected override void OnInitialized()
    {
        ShowProfileDetails = true;
    }

    public void OnShowProfileDetails()
    {
        ShowProfileDetails = true;
        ShowCustomLinks = false;
    }

    public void OnShowCustomLinks()
    {
        ShowProfileDetails = false;
        ShowCustomLinks = true;
    }

    public void OnProfileDetailsUpdated(ViewModels.ProfileDetails profileImageViewModel)
    {
        ProfileDetailsViewModel=profileImageViewModel;
    }

    public void OnCustomLinksUpdated(CustomizeLinks customizeLinksViewModel)
    {
        CustomizeLinksViewModel=customizeLinksViewModel;
    }
}
