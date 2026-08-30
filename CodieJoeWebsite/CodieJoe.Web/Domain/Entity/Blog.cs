using CodieJoe.Web.Domain.Enum;

namespace CodieJoe.Web.Domain.Entity;

public class Blog
{
    public Guid Id { get; set; }
    public string Heading { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public BlogStatus Status { get; set; }



    public ICollection<Tag> Tags { get; } = new List<Tag>();
}