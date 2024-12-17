using System.Security;

namespace ECommerce.Application.Authentication;

/// <summary>
/// Definition of the type that hashes the passwords.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Gets hash value for the password.
    /// </summary>
    /// <param name="password">
    /// Value that gonna hashed.
    /// </param>
    /// <returns>
    /// A read-only <see cref="SecureString"/> that holds password hash.
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    Task<SecureString> HashPasswordAsync(SecureString password);
}
