using CodieJoe.Web.Data.DataContext;
using CodieJoe.Web.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace CodieJoe.Web.Extentions.Identity;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>();


        return services;
    }
}