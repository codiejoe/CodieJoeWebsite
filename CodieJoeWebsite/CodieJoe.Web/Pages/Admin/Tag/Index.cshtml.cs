using CodieJoe.Web.Data.Repository.Interfaces;
using CodieJoe.Web.Pages.Admin.ViewModels.Requests;
using CodieJoe.Web.Pages.Admin.ViewModels.Response;
using CodieJoe.Web.Domain.Entity;
using CodieJoe.Web.Pages.ViewUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodieJoe.Web.Pages.Admin.Tag;

public class Index : PageModel
{
    private readonly ITagRepository _repository;

    public List<TagTableResponseVm> TableTags { get; } = [];

    [BindProperty]
    public TagAddRequestVm TagAddRequestVm { get; set; } = new();

    [BindProperty]
    public TagUpdateRequestVm TagUpdateRequestVm { get; set; } = new();
    
    public bool ShowAddModal { get; set; }
    public bool ShowEditModal { get; set; }

    public Index(ITagRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var tags = await _repository.GetTagSummariesAsync();

        foreach (var tag in tags)
        {
            TableTags.Add(new TagTableResponseVm
            {
                Id = tag.Id,
                Name = tag.Name,
                Slug = tag.Slug,
                NumberOfPosts = tag.NumberOfPosts
            });
        }

        return Page();
    }
    public async Task<IActionResult> OnPostCreateAsync()
    {
        ModelState.Clear();
        if (!TryValidateModel(TagAddRequestVm, nameof(TagAddRequestVm)))
        {
            ShowAddModal = true;
            await LoadTableTagsAsync(); 
            return Page();
        }

        var tag = new Domain.Entity.Tag
        {
            Name = TagAddRequestVm.Name.ToUpper(),
            Slug = TagAddRequestVm.Slug
        };

        await _repository.AddAsync(tag);
        return RedirectToPage(Routes.TagsPath);
    }

    public async Task<IActionResult> OnPostUpdateAsync()
    {
        ModelState.Clear();
        if (!TryValidateModel(TagUpdateRequestVm, nameof(TagUpdateRequestVm)))
        {
            ShowEditModal = true;
            await LoadTableTagsAsync();
            return Page();
        }

        var tag = await _repository.GetAsync(TagUpdateRequestVm.Id);
        if (tag is null) return NotFound();

        tag.Name = TagUpdateRequestVm.Name.ToUpper();
        tag.Slug = TagUpdateRequestVm.Slug;

        await _repository.UpdateAsync(tag);
        return RedirectToPage(Routes.TagsPath);
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        if (TagUpdateRequestVm.Id != Guid.Empty)
        {
            await _repository.DeleteAsync(TagUpdateRequestVm.Id);
        }

        return RedirectToPage(Routes.TagsPath);
    }

    private async Task LoadTableTagsAsync()
    {
        TableTags.Clear();
        var tags = await _repository.GetTagSummariesAsync();
        foreach (var tag in tags)
        {
            TableTags.Add(new TagTableResponseVm
            {
                Id = tag.Id,
                Name = tag.Name,
                Slug = tag.Slug,
                NumberOfPosts = tag.NumberOfPosts
            });
        }
    }
}