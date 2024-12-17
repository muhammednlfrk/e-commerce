namespace ECommerce.Domain.Entities;

/// <summary>
/// Base definition of <see cref="IEntity"/>.
/// </summary>
public abstract class EntityBase : IEntity
{
    /// <inheritdoc/>
    public virtual Guid Id { get; set; }

    /// <inheritdoc/>
    public virtual DateTime CreationTime { get; set; }

    /// <inheritdoc/>
    public virtual DateTime? LastModifiedTime { get; set; }

    /// <inheritdoc/>
    public virtual bool IsDeleted { get; set; }
}
