namespace ECommerce.Domain.Entities.Abstraction;

/// <summary>
/// Defines an entity.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Unique identifier of the <see cref="IEntity"/>.
    /// </summary>
    Guid Id { get; set; }

    /// <summary>
    /// Creation time of the <see cref="IEntity"/>.
    /// </summary>
    DateTime CreationTime { get; set; }

    /// <summary>
    /// The last modification time of the <see cref="IEntity"/>.
    /// </summary>
    DateTime? LastModifiedTime { get; set; }

    /// <summary>
    /// Determinates is the entity deleted or not.
    /// </summary>
    bool IsDeleted { get; set; }
}
