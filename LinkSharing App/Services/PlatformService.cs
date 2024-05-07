using LinkSharingRepository.Models;

namespace LinkSharing_App.Services
{
    public class PlatformService : IPlatformService
    {
        public IEnumerable<Platform> GetPlatforms()
        {
            return new List<Platform>() { new Platform { Id = 1, Name = "Stack Overflow", Icon = "icon-stack-overflow.svg", BrandingColor = "#f48024" },
                                                new Platform { Id = 2, Name = "You Tube", Icon = "icon-youtube.svg", BrandingColor = "#212121" },
                                                new Platform { Id = 3, Name = "GitHub", Icon = "icon-gitlab.svg", BrandingColor = "#333" },
                                                new Platform { Id = 4, Name = "Facebook", Icon = "icon-facebook.svg", BrandingColor = "#4267B2" },
                                                new Platform { Id = 5, Name = "Twitter", Icon = "icon-twitter.svg", BrandingColor = "#1DA1F2" },
                                                new Platform { Id = 7, Name = "Twitch", Icon = "icon-twitch.svg", BrandingColor = "#9146ff" },
                                                new Platform { Id = 8, Name = "LinkedIn", Icon = "icon-LinkedIn.svg", BrandingColor = "#0a66c2" } };
        }
    }
}
