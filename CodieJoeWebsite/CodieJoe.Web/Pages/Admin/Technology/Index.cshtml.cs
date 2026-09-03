using CodieJoe.Web.Data.Repository.Interfaces;
using CodieJoe.Web.Pages.Admin.ViewModels.Requests;
using CodieJoe.Web.Pages.Admin.ViewModels.Response;
using CodieJoe.Web.Pages.ViewUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodieJoe.Web.Pages.Admin.Technology;

public class Index : PageModel
{
    private readonly ITechnologyRepository _repository;
    public List<TechnologyResponseVM> TableTechnologies { get; set; } = [];

    [BindProperty] public TechnologyAddRequestVm TechnologyAddRequestVm { get; set; } = new();
    [BindProperty] public TechnologyUpdateRequestVm TechnologyUpdateRequestVm { get; set; } = new();
    public bool ShowAddModal { get; set; }
    public bool ShowEditModal { get; set; }

    public Index(ITechnologyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var technologies = (await _repository.GetAllAsync()).ToList();

        foreach (var technology in technologies)
        {
            TableTechnologies.Add(new TechnologyResponseVM
            {
                Id = technology.Id,
                Name = technology.Name,
                Slug = technology.Slug,
                Icon = technology.Icon ?? ""
            });
        }

        return Page();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        ModelState.Clear();
        if (!TryValidateModel(TechnologyAddRequestVm, nameof(TechnologyAddRequestVm)))
        {
            ShowAddModal = true;
            await LoadTableTechAsync();
            return Page();
        }

        await _repository.AddAsync(new Domain.Entity.Technology
        {
            Name = TechnologyAddRequestVm.Name.ToUpper(),
            Slug = TechnologyAddRequestVm.Slug,
            Icon = TechnologyAddRequestVm.Icon ?? "",
        });
        return RedirectToPage(@Routes.TechnologyPath);
    }

    public async Task<IActionResult> OnPostUpdateAsync()
    {
        ModelState.Clear();
        if (!TryValidateModel(TechnologyUpdateRequestVm, nameof(TechnologyUpdateRequestVm)))
        {
            ShowEditModal = true;
            await LoadTableTechAsync();
            return Page();
        }

        var technology = await _repository.GetAsync(TechnologyUpdateRequestVm.Id);
        if (technology is null) return NotFound();

        technology.Name = TechnologyUpdateRequestVm.Name.ToUpper();
        technology.Slug = TechnologyUpdateRequestVm.Slug;
        technology.Icon = TechnologyUpdateRequestVm.Icon ?? "";

        await _repository.UpdateAsync(technology);
        return RedirectToPage(@Routes.TechnologyPath);
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        if (TechnologyUpdateRequestVm.Id != Guid.Empty)
        {
            await _repository.DeleteAsync(TechnologyUpdateRequestVm.Id);
        }

        return RedirectToPage(@Routes.TechnologyPath);
    }

    private async Task LoadTableTechAsync()
    {
        TableTechnologies.Clear();
        var technologies = await _repository.GetAllAsync();

        TableTechnologies = technologies.Select(tech => new TechnologyResponseVM
        {
            Id = tech.Id,
            Name = tech.Name,
            Slug = tech.Slug,
            Icon = tech.Icon ?? ""
        }).ToList();
    }
}