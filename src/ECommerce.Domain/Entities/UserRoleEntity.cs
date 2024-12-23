using ECommerce.Domain.Entities.Abstraction;

namespace ECommerce.Domain.Entities;

/// <summary>
/// Defines user's roles.
/// </summary>
public class UserRoleEntity : ISecurityEntity
{
    /// <summary>
    /// The unique identifier of the user role definition.
    /// </summary>
    public int UserRoleId { get; set; }

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
    public int RoleGroupId { get; set; }

    /// <summary>
    /// The role group.
    /// </summary>
    public RoleGroupEntity? RoleGroup { get; set; }
}
