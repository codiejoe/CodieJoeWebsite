using System.ComponentModel.DataAnnotations;

namespace CodieJoe.Web.Pages.Admin.ViewModels.Requests;

public class TechnologyUpdateRequestVm
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string? Icon { get; set; }
    [Required] public string Slug { get; set; } = "";
}