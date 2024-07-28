using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class GenreConfigurations : BaseEntityConfigurations<Genre>
{
    public override void Configure(EntityTypeBuilder<Genre> builder)
    {
        base.Configure(builder);

        builder
            .Property(g => g.Description)
            .HasMaxLength(150);

        builder
            .HasIndex(g => g.Description)
            .IsUnique();


        builder
            .HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.IdGenre)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
