using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class UserBookConfigurations : BaseEntityConfigurations<UserBook>
{
    public override void Configure(EntityTypeBuilder<UserBook> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(ub => ub.Reviews)
            .WithOne(ubr => ubr.UserBook)
            .HasForeignKey(ubr => ubr.IdUserBook)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
