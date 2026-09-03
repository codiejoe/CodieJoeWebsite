namespace CodieJoe.Web.Pages.Admin.ViewModels.Response;

public class SocialsResponseVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Link { get; set; } = "";
    public int DisplayOrder { get; set; }
}