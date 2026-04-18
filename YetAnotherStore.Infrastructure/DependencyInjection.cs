using Microsoft.Extensions.DependencyInjection;

namespace YetAnotherStore.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container
    /// </summary>
    /// <param name="services">The service collection to which the infrastructure services will be added. Cannot be null.</param>
    /// <returns>The same instance of <see cref="IServiceCollection"/> with the infrastructure services registered.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
}
