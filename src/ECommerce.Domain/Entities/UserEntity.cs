namespace ECommerce.Domain.Entities;

/// <summary>
/// Defines the user entity.
/// </summary>
public class UserEntity : EntityBase, IEntity
{
    /// <summary>
    /// Users's name. Not same with the <see cref="UserName"/>.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// User's surname.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// One of the unique identifier of the <see cref="User"/>.
    /// </summary>
    public string? UserName { get; set; }
    
    /// <summary>
    /// User's hashed password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// User's e-mail address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// User's GSM number.
    /// </summary>
    public string? GSM { get; set; }

    /// <summary>
    /// The role list of user.
    /// </summary>
    public ICollection<UserRoleEntity>? Roles { get; set; }
}
