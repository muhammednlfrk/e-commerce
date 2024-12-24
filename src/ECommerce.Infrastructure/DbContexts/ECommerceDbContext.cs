using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Abstraction;
using ECommerce.Infrastructure.DbContexts.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.DbContexts;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations.
        modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RoleGroupEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleEntityConfiguration());

        // Add query filters etc.
        addIEntityQueryFilters(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private void addIEntityQueryFilters(ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .HasKey("Id");

                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime?>("LastModifiedTime")
                    .HasDefaultValue(null);

                modelBuilder.Entity(entityType.ClrType)
                    .Property<bool>("IsDeleted")
                    .HasDefaultValue(false);

                // e => e.IsDeleted == false
                ParameterExpression parameter = Expression.Parameter(entityType.ClrType, "e");
                ConstantExpression falseConstant = Expression.Constant(false);
                MemberExpression propertyAccess = Expression.PropertyOrField(parameter, nameof(IEntity.IsDeleted));
                BinaryExpression equalExpression = Expression.Equal(propertyAccess, falseConstant);
                LambdaExpression filter = Expression.Lambda(equalExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
    }

    #region DbSets

    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<RoleGroupEntity> RoleGroups { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRoleEntity> UserRoles { get; set; }

    #endregion
}
