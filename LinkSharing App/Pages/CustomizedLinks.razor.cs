
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
    public CustomizeLinksViewModel? CustomLinksViewModel { get; set; } = null;
    [Parameter]
    public EventCallback<CustomizeLinksViewModel> LinksUpdated {  get; set; }
    public bool CanAddLink => CustomLinksViewModel?.CustomLinks.Count < 7;
    private List<Platform> removedPlatforms  = new();

    protected override void OnInitialized()
    {

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        FilterPlatforms();
        base.OnParametersSet();
    }
     
    public void AddNewLink()
    {
        CustomLinkViewModel customLink = new();
        customLink.LinkUrl = "";
        CustomLinksViewModel?.AddLink(customLink);

    }

    public void RemoveLink(int linkId)
    {
        var removedLink=CustomLinksViewModel?.RemoveLink(linkId);
        if (removedLink != null)
        {
            var removedPlatform = removedPlatforms.FirstOrDefault(x => x.Id == removedLink.PlatformId);
            if (removedPlatform != null)
            {
                removedPlatforms.Remove(removedPlatform);
                Platforms.Add(removedPlatform);
            }

        }

    }

    public void OnPlatformSelected(int platformId, int linkId)
    {
        var customLinkVM = CustomLinksViewModel?.CustomLinks.First(x => x.DisplayIndex == linkId);
        if (customLinkVM != null && Platforms!=null)
        {
            var selectedPlatform = Platforms.First(x => x.Id == platformId);
            customLinkVM.PlatformId = selectedPlatform.Id;
            customLinkVM.PlatformName = selectedPlatform.Name;
            customLinkVM.PlatformURL = selectedPlatform.URL;
            customLinkVM.PlatformBrandingColor = selectedPlatform.BrandingColor;
            customLinkVM.PlatformIconPath = selectedPlatform.Icon;

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

    private void FilterPlatforms()
    {
        List<Platform>? selectablePlatforms = new();
        if (CustomLinksViewModel != null)
        {

            foreach (var platform in Platforms)
            {
                if (CustomLinksViewModel.HasPlatform(platform.Id))
                    removedPlatforms.Add(platform);
                else
                    selectablePlatforms.Add(platform);
         
                  
            }
                
        }

        Platforms= selectablePlatforms;
    }
}
