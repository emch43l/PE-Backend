using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructures(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        
        
        return serviceCollection;
    }
}