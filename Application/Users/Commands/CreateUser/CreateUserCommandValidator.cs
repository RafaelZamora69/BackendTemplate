using Application.Roles.Validations;
using Domain.Repositories;
using FluentValidation;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IRoleRepository repository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre es requerido");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida.");
        
        RuleFor(x => x.Surnames)
            .NotEmpty()
            .WithMessage("Los apellidos son requeridos.");
        
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("El usuario es requerido.");

        RuleFor(x => x.Role)
            .SetAsyncValidator(new RoleMustExistsValidator<CreateUserCommand>(repository));
    }
}