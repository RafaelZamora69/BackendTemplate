using System.Reflection;
using Application.Behaviors;

namespace Presentation.Setup;

public static class MediatRSetup
{

    public static void ConfigureMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            var applicationAssembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .First(a => a.GetName().Name.Contains("Application"));
            
            cfg.RegisterServicesFromAssembly(applicationAssembly);
            // Pipelines Behavior
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
    }
}