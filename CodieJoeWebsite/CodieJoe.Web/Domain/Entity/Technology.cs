namespace CodieJoe.Web.Domain.Entity;

public class Technology
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }

    public string Slug { get; set; } = string.Empty;

    public ICollection<Project> Projects { get;  } = new List<Project>();
}