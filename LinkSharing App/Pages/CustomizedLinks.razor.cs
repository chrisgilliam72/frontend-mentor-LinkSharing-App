
using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using LinkSharingRepository.Models;
using Microsoft.AspNetCore.Components;
using System;

namespace LinkSharing_App.Pages;

partial class CustomizedLinks
{
    [Parameter]
    public List<Platform>? Platforms { get; set; } = null;
    [Parameter]
    public CustomizeLinks? CustomLinksViewModel { get; set; } = null;
    [Parameter]
    public EventCallback<CustomizeLinks> LinksUpdated {  get; set; }
   


    public void AddNewLink()
    {
        CustomizedLink customLink = new();
        CustomLinksViewModel?.CustomLinks.Add(customLink);

    }

    public void RemoveLink(int linkId)
    {
        CustomLinksViewModel?.CustomLinks.Remove(CustomLinksViewModel.CustomLinks.First(x => x.PlatformLinkId == linkId));
    }

    public void OnPlatformSelected(int platformId, int linkId)
    {
        var customLinkVM = CustomLinksViewModel?.CustomLinks.First(x => x.PlatformLinkId == linkId);
        if (customLinkVM != null && Platforms!=null)
        {
            customLinkVM.Platform = Platforms.First(x => x.Id == platformId);
        }

    }

    public void OnSave()
    {
        LinksUpdated.InvokeAsync(CustomLinksViewModel);
    }
}
