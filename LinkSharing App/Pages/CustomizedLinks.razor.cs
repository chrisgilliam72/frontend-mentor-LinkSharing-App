
using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using LinkSharingRepository.Models;
using Microsoft.AspNetCore.Components;
using System;

namespace LinkSharing_App.Pages;

partial class CustomizedLinks
{
    [Inject]
    public IPlatformService PlatformService { get; set; }

    public List<Platform> Platforms = new();
    public CustomizeLinksViewModel ViewModel { get; set; } = new();
    [Parameter]
    public EventCallback<CustomizeLinksViewModel> LinksUpdated {  get; set; }
   
    protected override Task OnInitializedAsync()
    {
        Platforms.Clear();
        Platforms= PlatformService.GetPlatforms().OrderBy(x => x.Name).ToList();
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

    public void OnSave()
    {
        LinksUpdated.InvokeAsync(ViewModel);
    }
}
