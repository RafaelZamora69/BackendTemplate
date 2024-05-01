using Domain.Repositories;
using FluentValidation;
using Infrastructure.DataContext;

namespace Application.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{

    public CreateRoleCommandValidator(IPermissionRepository permissionRepository)
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

        var idWithError = 0;
        RuleFor(x => x.permissions)
            .MustAsync(async (list, cancellationToken) =>
            {
                var permissions = await Task.WhenAll(
                    list.Select(command => permissionRepository.Find(command.Id))
                );

                for (var i = 0; i < permissions.Length; i++)
                {
                    if (permissions.ElementAt(i) is not null) continue;
                    idWithError = list.ElementAt(i).Id;
                    return false;
                }

                return true;
            })
            .WithMessage($"El permiso: {idWithError}, no existe");
    }
    
}