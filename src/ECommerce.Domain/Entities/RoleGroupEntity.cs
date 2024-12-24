using ECommerce.Domain.Entities.Abstraction;

namespace ECommerce.Domain.Entities;

/// <summary>
/// Defines a user role group.
/// </summary>
public class RoleGroupEntity : ISecurityEntity
{
    /// <summary>
    /// The unique identifier of the role group.
    /// </summary>
    public int RoleGroupId { get; set; }

    /// <summary>
    /// Group's custom identity.
    /// </summary>
    public ulong GroupValue { get; set; }

    /// <summary>
    /// Group's name.
    /// </summary>
    public string? GroupName { get; set; }

    /// <summary>
    /// The role definition list of the group.
    /// </summary>
    public ICollection<RoleEntity>? Roles { get; set; }

    /// <summary>
    /// The user role definition list of the group.
    /// </summary>
    public ICollection<UserRoleEntity>? UserRoles { get; set; }
}
