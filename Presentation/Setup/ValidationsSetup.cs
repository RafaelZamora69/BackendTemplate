using Application.Users.Commands.CreateUser;
using FluentValidation;

namespace Presentation.Setup;

public static class ValidationsSetup
{

    public static void ConfigureValidators(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
    }
    
}