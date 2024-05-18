using LinkSharingRepository.Models;
namespace LinkSharing_App.ViewModels;

public class CustomizeLinks
{
    private List<CustomizedLink> _linksList = new();
    public List<CustomizedLink> CustomLinks => _linksList.OrderBy(x => x.DisplayIndex).ToList();
    private int nextDisplayIndex => CustomLinks.Max(x => x.DisplayIndex) + 1;

    public CustomizeLinks(IEnumerable<CustomLink> customLinks)
    {
        int index = 1;
        foreach (var link in customLinks)
        {
            CustomizedLink customizedLink = new()
            {
                Id = link.Id,
                Platform = link.Platform,
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

    public void AddLink(CustomizedLink customizedLink)
    {
        customizedLink.DisplayIndex = nextDisplayIndex;
        _linksList.Add(customizedLink);
    }

    public void RemoveLink(int displayIndex)
    {
        _linksList.Remove(CustomLinks.First(x => x.DisplayIndex == displayIndex));
        ReIndex();
    }

    public void ReIndex()
    {
        int index = 1;
        foreach (var link in _linksList)
            link.DisplayIndex = index++;
    }

}
