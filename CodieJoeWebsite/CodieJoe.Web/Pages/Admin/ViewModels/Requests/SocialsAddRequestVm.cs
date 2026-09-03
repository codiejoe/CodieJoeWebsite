using System.ComponentModel.DataAnnotations;

namespace CodieJoe.Web.Pages.Admin.ViewModels.Requests;

public class SocialsAddRequestVm
{
    [Required]
    [DataType(DataType.Text)]
    public string SocialMediaType { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Text)]
    public string Link { get; set; } = string.Empty;
    
    public int  DisplayOrder { get; set; }
}