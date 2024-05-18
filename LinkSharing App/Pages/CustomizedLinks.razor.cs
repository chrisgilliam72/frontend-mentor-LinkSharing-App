
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
        CustomLinksViewModel?.AddLink(customLink);

    }

    public void RemoveLink(int linkId)
    {
        CustomLinksViewModel?.RemoveLink(linkId);
    }

    public void OnPlatformSelected(int platformId, int linkId)
    {
        var customLinkVM = CustomLinksViewModel?.CustomLinks.First(x => x.DisplayIndex == linkId);
        if (customLinkVM != null && Platforms!=null)
        {
            customLinkVM.Platform = Platforms.First(x => x.Id == platformId);
        }

    }

    public void SortList((int oldIndex, int newIndex) indices)
    {
        // deconstruct the tuple
        var (oldIndex, newIndex) = indices;

        CustomLinksViewModel?.MoveLink(oldIndex, newIndex);
        StateHasChanged();
    }
    public void OnSave()
    {
        LinksUpdated.InvokeAsync(CustomLinksViewModel);
    }
}
