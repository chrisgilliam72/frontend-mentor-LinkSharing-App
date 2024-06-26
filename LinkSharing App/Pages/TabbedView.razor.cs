﻿using LinkSharing_App.Services;
using LinkSharing_App.ViewModels;
using LinkSharingRepository.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;

namespace LinkSharing_App.Pages;

partial class TabbedView
{
    [Inject]
    public IPlatformService PlatformService { get; set; }
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public ICustomLinkService CustomLinkService { get; set; }
    [Inject]
    NavigationManager NavigationManager { get; set; }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Parameter]
    public String UserId { get; set; } = "";

    public List<Platform> Platforms = new();
    public CustomizeLinksViewModel? CustomizeLinksViewModel { get; set; } = null;
    public ViewModels.ProfileDetails ProfileDetailsViewModel { get; set; } =  new ();
    public bool ShowProfileDetails { get; set; }
    public bool ShowCustomLinks {  get; set; }

    public bool ShowCustomlinkToast { get; set; } = false;
    public bool ShowProfileDetailsToast { get; set; } = false;
    public bool ShowPreviewToast { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        int userId = Convert.ToInt32(UserId);
        Platforms.Clear();
        Platforms = (await PlatformService.GetPlatforms()).OrderBy(x => x.Name).ToList();

        var user = await UserService.GetUser(userId);
        if (user != null)
        {
            ProfileDetailsViewModel.Id = user.Id;
            ProfileDetailsViewModel.Name = user.FirstName;
            ProfileDetailsViewModel.LastName = user.Surname;
            ProfileDetailsViewModel.EmailAddress = user.Email;
            ProfileDetailsViewModel.Photo = user.Photo;
            ProfileDetailsViewModel.PhotoFormat = user.PhotoFormat;
            ProfileDetailsViewModel.PublicURL = user.PublicURl;
        }
        var listLinks = (await CustomLinkService.GetCustomLinks(userId)).ToList();
        CustomizeLinksViewModel = new CustomizeLinksViewModel(listLinks);

        ShowProfileDetails = true;
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeAsync<object>("showToast");
        ShowCustomlinkToast = false;
        ShowProfileDetailsToast = false;
        ShowPreviewToast = false;
    }
    public async Task OnCopyLink()
    {
        await JSRuntime.InvokeVoidAsync("copyTextToClipboard", NavigationManager.BaseUri + $"{UserId}");
        ShowPreviewToast = true;
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

    public void OnShowMobilePreview()
    {
        NavigationManager.NavigateTo($"MobilePreview/{UserId}", true);
    }

    public async Task OnProfileDetailsUpdated(ViewModels.ProfileDetails profileImageViewModel)
    {
        ProfileDetailsViewModel=profileImageViewModel;
        User user = new()
        {
            Id = ProfileDetailsViewModel.Id,
            FirstName = ProfileDetailsViewModel.Name,
            Surname = ProfileDetailsViewModel.LastName,
            Email = ProfileDetailsViewModel.EmailAddress,
            Photo = ProfileDetailsViewModel.Photo,
            PhotoFormat = ProfileDetailsViewModel.PhotoFormat,
            PublicURl= ProfileDetailsViewModel.PublicURL
           
        };
        user = await UserService.UpdateUser(user);
        ShowProfileDetailsToast = true;
    }

    public async Task OnCustomLinksUpdated(CustomizeLinksViewModel customizeLinks)
    {
        CustomizeLinksViewModel= customizeLinks;
        foreach (var link in customizeLinks.CustomLinks)
        {
            if (link.Id==0) 
            {
                var dbLinkl = await CustomLinkService.AddCustomLink(link.PlatformId, Convert.ToInt32(UserId), link.LinkUrl, link.DisplayIndex);
                link.Id = dbLinkl.Id;
            }
            else
            {
                await CustomLinkService.UpdateCustomLink(link.Id, link.LinkUrl,link.DisplayIndex);
            }
        }
        while (customizeLinks.HasLinksToDelete)
        {
            var deleteLink= customizeLinks.GetNextLinktoToDelete();
            if (deleteLink != null)
            {
                await CustomLinkService.RemoveCustomLink(deleteLink.Id);
            }
        }
        ShowCustomlinkToast = true;

       
    }
}
