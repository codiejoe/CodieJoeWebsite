using CodieJoe.Web.Data.Repository.Implementations;
using CodieJoe.Web.Data.Repository.Interfaces;

namespace CodieJoe.Web.Extentions.Data;

public static class RepositoryLifetime
{
    public static IServiceCollection AddRepositoryLifetime(this IServiceCollection services)
    {
        services.AddScoped<ITagRepository, TagRepository>();
        
        return services;
    }
}