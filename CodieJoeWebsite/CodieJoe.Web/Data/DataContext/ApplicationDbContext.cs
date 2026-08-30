using CodieJoe.Web.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CodieJoe.Web.Data.DataContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Technology> Technologies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}