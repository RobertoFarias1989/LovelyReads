using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class UserBookReviewConfigurations : BaseEntityConfigurations<UserBookReview>
{
    public override void Configure(EntityTypeBuilder<UserBookReview> builder)
    {
        base.Configure(builder);

        builder
            .Property(br => br.Comment)
            .HasMaxLength(254);
    }
}
