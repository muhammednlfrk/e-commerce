namespace ECommerce.Domain.Entities;

/// <summary>
/// Defines a user role group.
/// </summary>
public class RoleGroupEntity : EntityBase, IEntity
{
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
    public List<RoleEntity>? Roles { get; set; }
}
