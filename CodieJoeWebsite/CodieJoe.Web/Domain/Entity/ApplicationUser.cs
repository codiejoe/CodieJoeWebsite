using Microsoft.AspNetCore.Identity;

namespace CodieJoe.Web.Domain.Entity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;

    public string? Bio { get; set; }

    public string? ProfileImageUrl { get; set; }

    public string? JobTitle { get; set; }
    
    
    public string FullName => $"{FirstName} {LastName}";
}