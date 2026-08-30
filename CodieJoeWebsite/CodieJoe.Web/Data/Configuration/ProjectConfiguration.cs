using CodieJoe.Web.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodieJoe.Web.Data.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // Table
        builder.ToTable("Projects");

        // Key
        builder.HasKey(p => p.Id);

        // Indexes
        builder.HasIndex(p => p.Slug)
            .IsUnique();

        // Properties
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Content)
            .HasColumnType("text");

        builder.Property(p => p.Slug)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.RepositoryLink)
            .HasMaxLength(2048);

        builder.Property(p => p.DemoLink)
            .HasMaxLength(2048);

        builder.Property(p => p.ImageLink)
            .HasMaxLength(2048);

        builder.Property(p => p.Featured)
            .HasDefaultValue(false);

        builder.Property(p => p.DisplayOrder)
            .HasDefaultValue(0);

        // Enum -> string
        builder.Property(p => p.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        // Dates
        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        // UpdatedAt is nullable by convention
        builder.Property(p => p.UpdatedAt);

        // Relationships
        builder.HasMany(p => p.Technologies)
            .WithMany(t => t.Projects)
            .UsingEntity<Dictionary<string, object>>(
                "ProjectTechnology",
                right => right
                    .HasOne<Technology>()
                    .WithMany()
                    .HasForeignKey("TechnologyId")
                    .OnDelete(DeleteBehavior.Cascade),
                left => left
                    .HasOne<Project>()
                    .WithMany()
                    .HasForeignKey("ProjectId")
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.HasKey("ProjectId", "TechnologyId");
                    join.ToTable("ProjectTechnologies");
                });
    }
}