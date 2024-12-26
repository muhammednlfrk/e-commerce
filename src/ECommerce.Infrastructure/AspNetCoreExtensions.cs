using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class AspNetCoreExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
#if DEBUG
        services.AddDbContext<ECommerceDbContext>(options =>
            options.UseInMemoryDatabase("ECommerceDb"));
#endif
#if !DEBUG
        services.AddDbContext<ECommerceDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
#endif

        // Add repositories.
        services.AddScoped<IUserRepository, UserRepositoryEfCore>();

        return services;
    }
}
