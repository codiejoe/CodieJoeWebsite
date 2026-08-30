using CodieJoe.Web.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodieJoe.Web.Data.Configuration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        // Table
        builder.ToTable("Blogs");

        // Key
        builder.HasKey(b => b.Id);

        // Indexes
        builder.HasIndex(b => b.Slug)
            .IsUnique();

        // Properties
        builder.Property(b => b.Heading)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(b => b.Content)
            .HasColumnType("text");

        builder.Property(b => b.Slug)
            .IsRequired()
            .HasMaxLength(150);

        // Dates
        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(b => b.UpdatedAt);

        // Enum -> string
        builder.Property(b => b.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        // Blog <-> Tag
        builder.HasMany(b => b.Tags)
            .WithMany(t => t.Blogs)
            .UsingEntity<Dictionary<string, object>>(
                "BlogTag",
                right => right
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .OnDelete(DeleteBehavior.Cascade),
                left => left
                    .HasOne<Blog>()
                    .WithMany()
                    .HasForeignKey("BlogId")
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.HasKey("BlogId", "TagId");
                    join.ToTable("BlogTags");
                });
    }
}