using CodieJoe.Web.Pages.ViewUtilities;

namespace CodieJoe.Web.Extentions.Web;

public static class WebConfiguration
{
    public static IServiceCollection ConfigureWebApplication(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.AccessDeniedPath = Routes.AccessDeniedPath;
            options.LoginPath = Routes.LoginPath;
            options.LogoutPath = Routes.LogoutPath;
            
        });
        
        return services;
    }
}