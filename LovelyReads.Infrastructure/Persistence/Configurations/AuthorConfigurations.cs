using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class AuthorConfigurations : BaseEntityConfigurations<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder
            .Property(a => a.Born)
            .HasMaxLength(254);

        builder
            .Property(a => a.Died)
            .HasMaxLength(254);

        builder
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.IdAuthor)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsOne(a => a.Name)
            .Property(n => n.FullName)
            .HasColumnName("FullName")
            .HasMaxLength(150);

    }
}
