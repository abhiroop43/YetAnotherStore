using Microsoft.Extensions.DependencyInjection;
using YetAnotherStore.Core.ServiceContracts;
using YetAnotherStore.Core.Services;

namespace YetAnotherStore.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Adds core application services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to which the core services will be added. Cannot be null.</param>
    /// <returns>The same instance of <see cref="IServiceCollection"/> with the core services registered.</returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
