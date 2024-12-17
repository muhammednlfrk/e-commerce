using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Helpers;
using ECommerce.Domain.Repositories;
using System.Security;

namespace ECommerce.Application.Authentication;

public class UserAuthenticator(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher) : IUserAuthenticator
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    /// <inheritdoc/>
    public async Task<User?> AuthenticateAsync(string userName, string password)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(userName, nameof(userName));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(password, nameof(password));

        using SecureString securePassword = password.ToReadOnlySecureString();
        SecureString securePasswordHashed = await _passwordHasher.HashPasswordAsync(securePassword);
        UserEntity? userEntity = await _userRepository.GetByUserNameAndPassword(
             userName: userName,
             password: securePasswordHashed.ConvertToUnsecureString());

        if (userEntity == null)
            return null;
        else if (userEntity.Roles == null || userEntity.Roles.Count == 0)
            UserAuthenticationException.Throw("The user's roles not found!");

        ArgumentNullException.ThrowIfNullOrEmpty(userEntity.FirstName, nameof(userEntity.FirstName));
        ArgumentNullException.ThrowIfNullOrEmpty(userEntity.LastName, nameof(userEntity.LastName));
        ArgumentNullException.ThrowIfNullOrEmpty(userEntity.UserName, nameof(userEntity.UserName));

        string email = userEntity.Email ?? string.Empty;
        string gsm = userEntity.GSM ?? string.Empty;
        User authenticatedUser = new(
            id:  userEntity.Id,
            firstName: userEntity.FirstName,
            lastName: userEntity.LastName,
            userName: userEntity.UserName,
            password: securePasswordHashed,
            email: ref email,
            gsm: ref gsm,
            roles: userEntity.GetRolesAsDictionary());
        userEntity = null;

        return authenticatedUser;
    }
}
