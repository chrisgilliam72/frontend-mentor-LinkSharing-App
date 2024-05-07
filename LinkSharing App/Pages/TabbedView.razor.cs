using LinkSharing_App.ViewModels;

namespace LinkSharing_App.Pages;

partial class TabbedView
{
    public ProfileDetailsViewModel ProfileDetailsViewModel { get; set; } =  new ();
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

    public void OnProfileDetailsUpdated(ProfileDetailsViewModel profileImageViewModel)
    {
        ProfileDetailsViewModel=profileImageViewModel;
    }
}
