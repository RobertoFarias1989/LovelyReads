using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class BookReviewConfigurations : BaseEntityConfigurations<BookReview>
{
    public override void Configure(EntityTypeBuilder<BookReview> builder)
    {
        base.Configure(builder);

        builder
            .Property(br => br.Comment)
            .HasMaxLength(254);
    }
}
