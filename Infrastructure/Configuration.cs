using Infrastructure.DB;
using Infrastructure.Identity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Configuration
{
    public static IServiceCollection ConfigureDb(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
                configuration.GetConnectionString("SqlServer") ??
                throw new ArgumentNullException(
                    configuration.GetConnectionString("SqlServer"),
                    "Could not find connection string for database !")
            )
        );
        
        return serviceCollection;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentityCore<UserEntity>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = true;
            options.Lockout.MaxFailedAccessAttempts = 3;
        }).AddRoles<UserRoleEntity>().AddEntityFrameworkStores<ApplicationDbContext>();
        
        return serviceCollection;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(
            options => options.RegisterServicesFromAssembly(typeof(Configuration).Assembly)
            );

        return serviceCollection;
    }
}