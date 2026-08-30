using System.ComponentModel.DataAnnotations;

namespace CodieJoe.Web.Pages.Admin.ViewModels.Requests;

public class TagUpdateRequestVm
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Slug { get; set; } = "";
}