
using LinkSharing_App.ViewModels;
using System;

namespace LinkSharing_App.Pages;

partial class CustomizedLinks
{
    public List<LinkPlatformViewModel> Platforms = new();
    public CustomizeLinksViewModel ViewModel { get; set; } = new();
    protected override Task OnInitializedAsync()
    {
        Platforms.Clear();
        Platforms.Add(new LinkPlatformViewModel(1, "Github"));
        Platforms.Add(new LinkPlatformViewModel(2, "YouTube"));
        Platforms.Add(new LinkPlatformViewModel(3, "LinkedIn"));
        Platforms.Add(new LinkPlatformViewModel(4, "Dev.to"));
        Platforms.Add(new LinkPlatformViewModel(6, "FreeCodeCamp"));
        Platforms.Add(new LinkPlatformViewModel(7, "FaceBook"));
        Platforms = Platforms.OrderBy(x=>x.Name).ToList();
        return base.OnInitializedAsync();
    }

    public void AddNewLink()
    {
        CustomizedLinkViewModel customLink = new();
        ViewModel.CustomLinks.Add(customLink);

    }
}
