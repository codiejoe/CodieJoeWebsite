using System.ComponentModel.DataAnnotations;

namespace CodieJoe.Web.Pages.Admin.ViewModels.Requests;

public class TechnologyAddRequestVm
{
    [Required] public string Name { get; set; } = "";
    [Required] public string Slug { get; set; } = "";
    public string? Icon { get; set; }
}