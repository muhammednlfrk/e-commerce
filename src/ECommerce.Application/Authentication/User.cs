using ECommerce.Domain.Helpers;
using System.Security;

namespace ECommerce.Application.Authentication;

/// <summary>
/// Defines a <see cref="User"/> that uses the services and etc.
/// </summary>
public sealed class User : IDisposable
{
    /// <summary>
    /// Generates an instance of the <see cref="User"/>.
    /// </summary>
    /// <param name="id">
    /// Unique identifier of the id.
    /// </param>
    /// <param name="firstName">
    /// The name of the user.
    /// </param>
    /// <param name="lastName">
    /// The surname of the user.
    /// </param>
    /// <param name="userName">
    /// One of the unique identifiers of the user.
    /// </param>
    /// <param name="password">
    /// Hashed password of the user.
    /// </param>
    /// <param name="email">
    /// E-mail of the user.
    /// </param>
    /// <param name="gsm">
    /// GSM number of the user.
    /// </param>
    /// <param name="roles">
    /// Definitions of the user roles.
    /// </param>
    public User(
        Guid id,
        string firstName,
        string lastName,
        string userName,
        SecureString password,
        ref string email,
        ref string gsm,
        IReadOnlyDictionary<ulong, ulong> roles)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Password = password;
        Email = email.ToReadOnlySecureString();
        Gsm = gsm.ToReadOnlySecureString();
        Roles = roles;
    }

    /// <summary>
    /// The unique identifier of the <see cref="User"/>.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Users's name. Not same with the <see cref="UserName"/>.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// User's surname.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// One of the unique identifier of the <see cref="User"/>.
    /// </summary>
    public string UserName { get; }

    /// <summary>
    /// User's hashed password.
    /// </summary>
    public SecureString Password { get; }

    /// <summary>
    /// User's e-mail address.
    /// </summary>
    public SecureString Email { get; }

    /// <summary>
    /// User's GSM number.
    /// </summary>
    public SecureString Gsm { get; }

    /// <summary>
    /// Spesifies user role groups and user roles.
    /// <br/>
    /// <i>key:</i> Role group id.<br/>
    /// <i>value:</i> Role value by group.<br/>
    /// </summary>
    public IReadOnlyDictionary<ulong, ulong> Roles { get; }

    /// <inheritdoc/>
    public void Dispose()
    {
        Password.Dispose();
        Email.Dispose();
        Gsm.Dispose();
        GC.SuppressFinalize(this);
    }
}
