namespace LinkSharing_App.Pages;

partial class TabbedView
{
    
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
}
