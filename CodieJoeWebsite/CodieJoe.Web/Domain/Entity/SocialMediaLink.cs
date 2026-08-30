using CodieJoe.Web.Domain.Enum;

namespace CodieJoe.Web.Domain.Entity;

public class SocialMediaLink
{
    public Guid Id { get; set; }

    public SocialMediaType Type { get; set; }

    public string Link { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }
}