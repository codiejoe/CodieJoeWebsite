using CodieJoe.Web.Domain.Entity;
using CodieJoe.Web.Domain.Models;
using CodieJoe.Web.Pages.Admin.ViewModels.Response;

namespace CodieJoe.Web.Data.Repository.Interfaces;

public interface ITagRepository : ICrudRepository<Tag,Guid>
{
    Task<IEnumerable<TagSummary>> GetTagSummariesAsync();
}