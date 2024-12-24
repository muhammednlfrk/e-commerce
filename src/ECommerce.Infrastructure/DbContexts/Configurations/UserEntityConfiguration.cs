using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.DbContexts.Configurations;

internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.Property(e => e.FirstName)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(e => e.Password)
            .HasMaxLength(64)
            .IsFixedLength()
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(320)
            .IsRequired();

        builder.Property(e => e.IsEmailConfirmed)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.IsEmail2FAEnabled)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.GSM)
            .HasMaxLength(15)
            .IsRequired(false);

        builder.Property(e => e.IsGSMConfirmed)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.IsGSM2FAEnabled)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasMany(e => e.Roles)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
    }
}
