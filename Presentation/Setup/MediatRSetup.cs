namespace Presentation.Setup;

public static class MediatRSetup
{

    public static void ConfigureMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        // Pipelines Behavior
    }
}