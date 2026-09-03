using CodieJoe.Web.Data.DataContext;
using CodieJoe.Web.Data.Repository.Interfaces;
using CodieJoe.Web.Domain.Entity;

namespace CodieJoe.Web.Data.Repository.Implementations;

public class TechnologyRepository : CrudRepository<Technology, Guid>, ITechnologyRepository
{
    public TechnologyRepository(ApplicationDbContext context) : base(context)
    {
    }
}