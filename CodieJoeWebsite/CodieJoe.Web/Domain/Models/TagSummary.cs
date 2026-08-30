namespace CodieJoe.Web.Domain.Models;

public class TagSummary
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Slug { get; init; } = string.Empty;
    public int NumberOfPosts { get; init; }
}