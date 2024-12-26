using ECommerce.Domain.Entities.Abstraction;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories;
public abstract class EFCoreRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
{
    protected readonly ECommerceDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public EFCoreRepositoryBase(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    /// <inheritdoc/>
    public virtual async Task<TEntity?> CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    /// <inheritdoc/>
    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        bool hasEntity = await _dbSet.AnyAsync(e => e.Id == id);
        if (!hasEntity) return false;
        _dbSet.Remove(new TEntity { Id = id });
        await _dbContext.SaveChangesAsync();
        return true;
    }

    /// <inheritdoc/>
    public virtual async Task<TEntity?> GetAsync(Guid id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    /// <inheritdoc/>
    public virtual async Task<ICollection<TEntity>?> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    /// <inheritdoc/>
    public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}
