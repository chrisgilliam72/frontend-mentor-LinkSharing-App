using LinkSharingRepository.Models;
using System.ComponentModel.DataAnnotations;
namespace LinkSharing_App.ViewModels;

public class CustomizeLinksViewModel
{
    private List<CustomLinkViewModel> _linksList = new();
    private List<CustomLinkViewModel> _removeList = new();
    [ValidateComplexType]
    public List<CustomLinkViewModel> CustomLinks => _linksList.OrderBy(x => x.DisplayIndex).ToList();
    private int nextDisplayIndex => _linksList.Any() ? _linksList.Max(x => x.DisplayIndex) + 1 : 1;

    public List<int> SelectedPlatformIds => _linksList.Select(x => x.PlatformId).ToList();

    public bool IsValid => _linksList.All(x => x.IsValidURL);
    public bool HasPlatform(int platformId)
    {
        return _linksList.FirstOrDefault(x => x.PlatformId == platformId) != null;
    }

    public CustomLinkViewModel GetNextLinktoToDelete()
    {
        if (_removeList.Any())
        {
            var removeLink = _removeList[0];
            _removeList.Remove(removeLink);
            return removeLink;
        }

        return null;
    }

    public bool HasLinksToDelete => _removeList.Any();
    public CustomizeLinksViewModel(IEnumerable<CustomLink> customLinks)
    {
        int index = 1;
        foreach (var link in customLinks)
        {
            CustomLinkViewModel customizedLink = new()
            {
                Id = link.Id,
                PlatformId = link.Platform.Id,
                PlatformIconPath = @"/img/" + link.Platform.Icon,
                PlatformName = link.Platform.Name,
                PlatformURL = link.Platform.URL,
                PlatformBrandingColor = link.Platform.BrandingColor,
                LinkUrl = link.URL,
                DisplayIndex = index++,
            };
            _linksList.Add(customizedLink);
        }
    }

    public void MoveLink(int oldIndex, int newIndex)
    {

        var itemToMove = _linksList[oldIndex];
        _linksList.RemoveAt(oldIndex);

        if (newIndex < _linksList.Count)
        {
            _linksList.Insert(newIndex, itemToMove);
        }
        else
        {
            _linksList.Add(itemToMove);
        }

        ReIndex();
    }

    public void AddLink(CustomLinkViewModel customizedLink)
    {
        customizedLink.DisplayIndex = nextDisplayIndex;
        _linksList.Add(customizedLink);

    }

    public CustomLinkViewModel RemoveLink(int displayIndex)
    {
        var link = CustomLinks.First(x => x.DisplayIndex == displayIndex);
        _linksList.Remove(link);
        _removeList.Add(link);
        ReIndex();
        return link;
    }

    public void ReIndex()
    {
        int index = 1;
        foreach (var link in _linksList)
            link.DisplayIndex = index++;
    }

    public void UseWhiteIcons()
    {
        foreach (var customLink in _linksList)
        {
            if (!customLink.PlatformIconPath.Contains("-white."))
            {
                customLink.PlatformIconPath = customLink.PlatformIconPath.Replace(".", "-white.");
            }

        }
    }
}
