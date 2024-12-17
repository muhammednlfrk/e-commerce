using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Repositories;

/// <summary>
/// Defines a repository that gets data paged.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IPagedRepository<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Gets data page by page without a condition.
    /// </summary>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">Entity count on the page.</param>
    /// <returns>
    /// Returns <paramref name="pageSize"/> sized list of the <typeparamref name="TEntity"/>.
    /// </returns>
    Task<ICollection<TEntity>?> GetPagedAsync(uint pageNumber, uint pageSize);
}
