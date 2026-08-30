using CodieJoe.Web.Domain.Entity;

namespace CodieJoe.Web.Data.Repository.Interfaces;

public interface IBlogRepository : ICrudRepository<Blog, Guid>
{
    
}