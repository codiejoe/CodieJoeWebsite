using CodieJoe.Web.Domain.Enum;

namespace CodieJoe.Web.Domain.Entity;

public class Project
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Content { get; set; } 
    public string Slug { get; set; } = string.Empty;
    public string? RepositoryLink { get; set; }
    public string? DemoLink { get; set; }
    public string? ImageLink { get; set; } 
    public bool Featured { get; set; }
    public int DisplayOrder { get; set; }
    public ProjectStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }

    public ICollection<Technology> Technologies { get; } = new List<Technology>();
}