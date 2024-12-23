namespace ECommerce.Domain.Entities;

/// <summary>
/// Defines user's roles.
/// </summary>
public class UserRoleEntity : EntityBase, IEntity
{
    /// <summary>
    /// The value that keeps user role identifiers.
    /// </summary>
    public ulong UserRoles { get; set; }

    /// <summary>
    /// User's unique identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The user has the defined roles for the group.
    /// </summary>
    public UserEntity? User { get; set; }

    /// <summary>
    /// The role group unique identifier.
    /// </summary>
    public ulong RoleGroupValue { get; set; }

    /// <summary>
    /// The id of the <see cref="RoleGroup"/>.
    /// </summary>
    public Guid RoleGroupId { get; set; }

    /// <summary>
    /// The role group.
    /// </summary>
    public RoleGroupEntity? RoleGroup { get; set; }
}
