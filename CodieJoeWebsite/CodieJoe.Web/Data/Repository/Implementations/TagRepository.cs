using CodieJoe.Web.Data.DataContext;
using CodieJoe.Web.Data.Repository.Interfaces;
using CodieJoe.Web.Domain.Entity;
using CodieJoe.Web.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CodieJoe.Web.Data.Repository.Implementations;

public class TagRepository : CrudRepository<Tag, Guid>, ITagRepository

{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TagSummary>> GetTagSummariesAsync()
    {
        return await _context.Tags
            .Select(t => new TagSummary
            {
                Id = t.Id,
                Name = t.Name,
                Slug = t.Slug,
                NumberOfPosts = t.Blogs.Count
            })
            .ToListAsync();
    }
}