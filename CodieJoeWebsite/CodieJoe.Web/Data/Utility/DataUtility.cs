using CodieJoe.Web.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CodieJoe.Web.Data.Utility;

public static class DataUtility
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.EnableDetailedErrors();
            
        });
        return services;
    }
}