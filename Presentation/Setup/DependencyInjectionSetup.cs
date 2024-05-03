using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Setup;

public static class DependencyInjectionSetup
{
    
    public static void ConfigureDependencyInjectionContainer(this IServiceCollection serviceCollection)
    {
        // Todas las dependecias del DI Container deben de ser Scoped
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IRoleRepository, RoleRepository>();
        serviceCollection.AddScoped<IPermissionRepository, PermissionRepository>();
        serviceCollection.AddScoped<IAuthorizationHandler, CanAuthorizationHandler>();
    }
}