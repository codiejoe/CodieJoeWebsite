using CodieJoe.Web.Domain.Enum;

namespace CodieJoe.Web.Pages.ViewUtilities;

public static class Socials
{
    public static readonly Dictionary<SocialMediaType, string> Get = new()
    {
        { SocialMediaType.GitHub, "/icons/socials/github/Github.png" },
        { SocialMediaType.LinkedIn, "/icons/socials/linkedin/LinkedIn.png" },
        { SocialMediaType.X, "/icons/socials/twitter/Twitter.png" },
        { SocialMediaType.YouTube, "/icons/socials/youtube/Youtube.png" },
        { SocialMediaType.Instagram, "/icons/socials/instagram/Instagram.png" },
        { SocialMediaType.Website, "/icons/socials/web/Web.png" },
        { SocialMediaType.Email, "/icons/socials/outlook/Outlook.png" },
      
    };
}