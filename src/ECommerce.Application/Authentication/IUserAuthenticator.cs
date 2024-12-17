using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Authentication;

/// <summary>
/// Defines funtionalities that for authenticate <see cref="User"/>s.
/// </summary>
public interface IUserAuthenticator
{
    /// <summary>
    /// Authenticates users and get their informations, if the authentication is successful.
    /// </summary>
    /// <param name="userName">User's unique identifier to login.</param>
    /// <param name="password">User's password.</param>
    /// <returns>
    /// If user authenticated successfully returns user's information.
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="UserAuthenticationException"/>
    Task<User?> AuthenticateAsync(string userName, string password);
}
