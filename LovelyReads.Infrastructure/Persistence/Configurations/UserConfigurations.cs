using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LovelyReads.Infrastructure.Persistence.Configurations;

public class UserConfigurations : BaseEntityConfigurations<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(u => u.BookReviews)
            .WithOne(br => br.User)
            .HasForeignKey(br => br.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        //Name
        builder
            .OwnsOne(u => u.Name)
            .Property(n => n.FullName)
            .HasColumnName("FullName")
            .HasMaxLength(150);

        //CPF
        builder
            .OwnsOne(u => u.CPF)
            .Property(c => c.CPFNumber)
            .HasColumnName("CPFNumber")
            .HasMaxLength(11);

        builder
            .OwnsOne(u => u.CPF,
            cpf =>
            {
                cpf.HasIndex(c => c.CPFNumber)
                .IsUnique();
            });

        //Email
        builder
            .OwnsOne(u => u.Email)
            .Property(e => e.EmailAddress)
            .HasColumnName("EmailAddress")
            .HasMaxLength(100);

        builder
            .OwnsOne(u => u.Email,
            email =>
            {
                email.HasIndex(e => e.EmailAddress)
                .IsUnique();
            });

        //Address
        builder
            .OwnsOne(u => u.Address)
            .Property(a => a.Street)
            .HasColumnName("Street")
            .HasMaxLength(100);

        builder
            .OwnsOne(u => u.Address)
            .Property(a => a.City)
            .HasColumnName("City")
            .HasMaxLength(100);

        builder
            .OwnsOne(u => u.Address)
            .Property(a => a.State)
            .HasColumnName("State")
            .HasMaxLength(100);

        builder
            .OwnsOne(u => u.Address)
            .Property(a => a.PostalCode)
            .HasColumnName("PostalCode")
            .HasMaxLength(100);

        builder
           .OwnsOne(u => u.Address)
           .Property(a => a.Country)
           .HasColumnName("Country")
           .HasMaxLength(50);

        //Password
        builder
            .OwnsOne(u => u.Password)
            .Property(p => p.PasswordValue)
            .HasColumnName("Password")
            .HasMaxLength(100);

    }
}
