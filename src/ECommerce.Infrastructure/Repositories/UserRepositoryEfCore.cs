using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories;

public class UserRepositoryEfCore(ECommerceDbContext dbContext) :
    EFCoreRepositoryBase<UserEntity>(dbContext), IUserRepository
{
    /// <inheritdoc/>
    public async Task<UserEntity?> GetByUserNameAndPassword(string userName, string password)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
    }
}
