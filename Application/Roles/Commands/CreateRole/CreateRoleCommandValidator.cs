using Application.Permissions.Validations;
using Domain.Repositories;
using FluentValidation;

namespace Application.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{

    public CreateRoleCommandValidator(IPermissionRepository repository)
    {
        RuleFor(x => x.name)
            .NotEmpty()
            .WithMessage("El nombre es requerido");

        RuleFor(x => x.name)
            .MinimumLength(5)
            .WithMessage("El nombre debe de contener al menos 5 caracteres");

        RuleFor(x => x.name)
            .Must(x => x.All(char.IsLetter))
            .WithMessage("El nombre solo debe contener letras.");

        RuleFor(x => x.permissions)
            .SetAsyncValidator(new PermissionsMustExistsValidator<CreateRoleCommand>(repository));
    }
    
}