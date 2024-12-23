using ECommerce.Domain.Exceptions;

namespace ECommerce.Application.Authentication;

/// <summary>
/// Defines funtionalities that for authenticate <see cref="User"/>s.
/// </summary>
public interface IUserAuthenticator
{
    /// <summary>
    /// Checks the user if it's authenticated(logged in) or not.
    /// </summary>
    /// <param name="user">User gonna be checked</param>
    /// <returns>Return true if user authenticated, else returns false.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    Task<bool> IsAuthenticatedAsync(User user);

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
    Task<User?> LogInAsync(string userName, string password);

    /// <summary>
    /// Removes user from authenticated user list.
    /// </summary>
    /// <param name="user">User that gonna log-out.</param>
    /// <returns>Returns true if user log outs successfully</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="UserAuthenticationException"/>
    Task<bool> LogOutAsync(User user);
}
