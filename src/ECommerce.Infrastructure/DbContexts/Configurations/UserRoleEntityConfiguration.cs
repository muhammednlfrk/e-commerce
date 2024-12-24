using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.DbContexts.Configurations;

internal class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasKey(e => e.UserRoleId);

        builder.Property(e => e.UserRoles)
            .IsRequired(true);

        builder.Property(e => e.UserId)
            .IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(e => e.Roles);

        builder.HasOne(e => e.RoleGroup)
            .WithMany(e => e.UserRoles);
    }
}
