using CodieJoe.Web.Data.DataContext;
using CodieJoe.Web.Data.Repository.Interfaces;
using CodieJoe.Web.Domain.Entity;

namespace CodieJoe.Web.Data.Repository.Implementations;

public class SocialsRepository : CrudRepository<SocialMediaLink, Guid>, ISocialsRepository
{
    public SocialsRepository(ApplicationDbContext context) : base(context)
    {
    }
}