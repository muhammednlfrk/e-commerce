using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Helpers;

public static class EntityExtensions
{
    /// <summary>
    /// Gets user's roles as dictionary.
    /// </summary>
    /// <param name="userEntity">The user that roles gonna converted.</param>
    /// <returns>
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    public static IReadOnlyDictionary<ulong, ulong> GetRolesAsDictionary(this UserEntity userEntity)
    {
        if (userEntity.Roles == null)
            ArgumentNullException.ThrowIfNull(userEntity.Roles, nameof(userEntity.Roles));
        Dictionary<ulong, ulong> roles = new(userEntity.Roles.Count);
        foreach (UserRoleEntity role in userEntity.Roles)
            roles.Add(role.RoleGroupValue, role.UserRoles);
        return roles.AsReadOnly();
    }
}
