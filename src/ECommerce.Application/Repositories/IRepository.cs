using ECommerce.Domain.Entities.Abstraction;

namespace ECommerce.Application.Repositories;

/// <summary>
/// Defines funcitonalities for the CRUD operations of the <typeparamref name="TEntity"/>.
/// </summary>
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Gets the <typeparamref name="TEntity"/> by id.
    /// </summary>
    /// <param name="id">The unique identifier of the <typeparamref name="TEntity"/>.</param>
    /// <returns>
    /// Gets <typeparamref name="TEntity"/> if its exists else returns null.
    /// </returns>
    Task<TEntity?> GetAsync(Guid id);

    /// <summary>
    /// Gets all data from the repository. Be careful when you're using this function!
    /// </summary>
    /// <returns>All <typeparamref name="TEntity"/>.</returns>
    Task<ICollection<TEntity>?> GetAllAsync();

    /// <summary>
    /// Creates a <typeparamref name="TEntity"/>. If its fails returns null but its
    /// depends on the implementation. Maybe any exception can occour.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> that gonna add to repository.</param>
    /// <returns>
    /// Returns the entity if the creation is completed successfully otherwise returns null or
    /// throws an exception depending on the repository implementation.
    /// </returns>
    Task<TEntity?> CreateAsync(TEntity entity);

    /// <summary>
    /// Updates the <paramref name="entity"/> depending on the <see cref="IEntity.Id"/> value.
    /// </summary>
    /// <param name="entity">The entity that gonna get updated.</param>
    /// <returns>
    /// Returns the entity with updated values if the update is completed successfully
    /// otherwise returns null or throws an exception depending on the repository
    /// implementation.
    /// </returns>
    Task<TEntity?> UpdateAsync(TEntity entity);

    /// <summary>
    /// Deletes the entity depending on <paramref name="id"/>.
    /// </summary>
    /// <param name="id"><see cref="IEntity.Id"/> of the entity that gonna be deleted.</param>
    /// <returns>Returns <c>true</c> if entity successfully deleted else returns <c>false</c>.</returns>
    Task<bool> DeleteAsync(Guid id);
}

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
