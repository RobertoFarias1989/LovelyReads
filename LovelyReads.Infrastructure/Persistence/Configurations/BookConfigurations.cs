using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class BookConfigurations : BaseEntityConfigurations<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder
            .Property(b => b.Title)
            .HasMaxLength(150);

        builder
            .Property(b => b.Description)
            .HasMaxLength(254);

        builder
            .Property(b => b.Publisher)
            .HasMaxLength(100);

        builder
            .HasMany(b => b.reviews)
            .WithOne(br => br.Book)
            .HasForeignKey(br => br.IdBook)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
