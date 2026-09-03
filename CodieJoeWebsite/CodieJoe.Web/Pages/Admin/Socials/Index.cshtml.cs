using CodieJoe.Web.Data.Repository.Interfaces;
using CodieJoe.Web.Domain.Enum;
using CodieJoe.Web.Pages.Admin.ViewModels.Requests;
using CodieJoe.Web.Pages.Admin.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodieJoe.Web.Pages.Admin.Socials;

public class Index : PageModel
{
    private readonly ISocialsRepository _socialsRepository;
    [BindProperty] public List<SocialsResponseVm> TableSocials { get; set; } = [];

    [BindProperty] public SocialsAddRequestVm SocialsAddRequestVm { get; set; } = new();
    
    public List<SelectListItem> SocialMediaTypeList { get; set; } = Enum.GetValues<SocialMediaType>()
        .Select(e => new SelectListItem
        {
            Value = e.ToString(),
            Text = e.ToString()
        })
        .ToList();


    public Index(ISocialsRepository socialsRepository)
    {
        _socialsRepository = socialsRepository;
        
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var socials = (await _socialsRepository.GetAllAsync()).ToList();
        foreach (var social in socials)
        {
            TableSocials.Add(new SocialsResponseVm
            {
                Id = social.Id,
                Name = social.Type.ToString(),
                DisplayOrder = social.DisplayOrder,
                Link = social.Link,
            });
        }

        return Page();
    }

    public async Task<IActionResult> OnCreateAsync()
    {
        throw new NotImplementedException();
    }
}