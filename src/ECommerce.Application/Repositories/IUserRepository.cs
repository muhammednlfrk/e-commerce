using ECommerce.Domain.Entities;

namespace ECommerce.Application.Repositories;

/// <summary>
/// Definition of a repository for <see cref="UserEntity"/> entities.
/// </summary>
public interface IUserRepository : IRepository<UserEntity>
{
    /// <summary>
    /// Gets user by username and password.
    /// </summary>
    /// <param name="userName">User's username.</param>
    /// <param name="password">User's not hashed password.</param>
    /// <returns>
    /// If user exists with provided <paramref name="userName"/> and <paramref name="password"/>
    /// returns <see cref="UserEntity"/>'s information and roles.
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    Task<UserEntity?> GetByUserNameAndPassword(string userName, string password);
}