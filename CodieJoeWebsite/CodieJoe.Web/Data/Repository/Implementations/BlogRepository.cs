using CodieJoe.Web.Data.DataContext;
using CodieJoe.Web.Data.Repository.Interfaces;
using CodieJoe.Web.Domain.Entity;

namespace CodieJoe.Web.Data.Repository.Implementations;

public class BlogRepository : CrudRepository<Blog, Guid>, IBlogRepository
{
    public BlogRepository(ApplicationDbContext context) : base(context)
    {
    }
}