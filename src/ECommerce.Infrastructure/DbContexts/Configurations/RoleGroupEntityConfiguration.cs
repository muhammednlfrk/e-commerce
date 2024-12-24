using ECommerce.Domain.Entities;    
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.DbContexts.Configurations;

internal class RoleGroupEntityConfiguration : IEntityTypeConfiguration<RoleGroupEntity>
{
    public void Configure(EntityTypeBuilder<RoleGroupEntity> builder)
    {
        builder.ToTable("RoleGroups");
        builder.HasKey(e => e.RoleGroupId);

        builder.Property(e => e.GroupValue)
            .IsRequired();

        builder.Property(e => e.GroupName)
            .IsRequired();

        builder.HasMany(e => e.Roles)
            .WithOne(e => e.RoleGroup);
    }
}
