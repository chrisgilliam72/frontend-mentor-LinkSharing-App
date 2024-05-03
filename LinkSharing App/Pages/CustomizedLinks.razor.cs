
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
        Platforms.Add(new LinkPlatformViewModel(1, "Github", "/img/icon-github.svg"));
        Platforms.Add(new LinkPlatformViewModel(2, "YouTube", "/img/icon-youtube.svg"));
        Platforms.Add(new LinkPlatformViewModel(3, "LinkedIn", "/img/icon-linkedin.svg"));
        Platforms.Add(new LinkPlatformViewModel(4, "Dev.to", "/img/icon-devto.svg"));
        Platforms.Add(new LinkPlatformViewModel(6, "FreeCodeCamp", "/img/icon-freecodecamp.svg"));
        Platforms.Add(new LinkPlatformViewModel(7, "FaceBook", "/img/icon-facebook.svg"));
        Platforms = Platforms.OrderBy(x=>x.Name).ToList();
        return base.OnInitializedAsync();
    }


    public void AddNewLink()
    {
        CustomizedLinkViewModel customLink = new();
        ViewModel.CustomLinks.Add(customLink);

    }

    public void RemoveLink(int linkId)
    {
        ViewModel.CustomLinks.Remove(ViewModel.CustomLinks.First(x => x.PlatformLinkId == linkId));
    }

    public void OnPlatformSelected(int platformId, int linkId)
    {
        var customLinkVM = ViewModel.CustomLinks.First(x => x.PlatformLinkId == linkId);
        customLinkVM.Platform= Platforms.First(x =>x.Id == platformId); 
    }
}
