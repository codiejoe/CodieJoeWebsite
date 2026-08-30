using CodieJoe.Web.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodieJoe.Web.Data.Configuration;

public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        // Table
        builder.ToTable("Technologies");

        // Key
        builder.HasKey(t => t.Id);

        // Indexes
        builder.HasIndex(t => t.Slug)
            .IsUnique();

        // Properties
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Slug)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Icon)
            .HasMaxLength(2048);


    }
}