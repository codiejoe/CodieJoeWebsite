using CodieJoe.Web.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodieJoe.Web.Data.Configuration;

public class SocialMediaLinkConfiguration : IEntityTypeConfiguration<SocialMediaLink>
{
    public void Configure(EntityTypeBuilder<SocialMediaLink> builder)
    {
        builder.ToTable("SocialMediaLinks");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Type)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(s => s.Link)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(s => s.DisplayOrder)
            .HasDefaultValue(0);
    }
}