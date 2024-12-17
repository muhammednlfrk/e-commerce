namespace ECommerce.Domain.Entities;

/// <summary>
/// Defines a user role
/// </summary>
public class RoleEntity : EntityBase, IEntity
{
    /// <summary>
    /// Role's custom identificator.
    /// </summary>
    public ulong RoleValue { get; set; }

    /// <summary>
    /// Role's name.
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// The role's group id.
    /// </summary>
    public ulong RoleGroupId { get; set; }

    /// <summary>
    /// The role's group.
    /// </summary>
    public RoleGroupEntity? RoleGroup { get; set; }
}
