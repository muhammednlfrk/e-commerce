using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.DbContexts.Configurations;

internal class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(e => e.RoleId);

        builder.Property(e => e.RoleValue)
            .IsRequired();

        builder.Property(e => e.RoleName)
            .IsRequired();

        builder.Property(e => e.RoleGroupId)
            .IsRequired();

        builder.HasOne(e => e.RoleGroup)
            .WithMany(e => e.Roles)
            .HasForeignKey(e => e.RoleGroupId);
    }
}
