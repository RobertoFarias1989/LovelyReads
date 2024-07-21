using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(b => b.Id);

        //builder
        //    .Property(b => b.CreatedAt)
        //    .HasColumnName("datetime");

        //builder
        //    .Property(b => b.UpdatedAt)
        //    .HasColumnName("datetime");

    }
}
