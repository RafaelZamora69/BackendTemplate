using Domain.Entities;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Permissions.Validations;

public class PermissionsMustExistsValidator<T>(IPermissionRepository repository) 
    : AsyncPropertyValidator<T, IList<Permission>>
{
    
    public override string Name { get; }

    public override async Task<bool> IsValidAsync(ValidationContext<T> context, IList<Permission> value, CancellationToken cancellation)
    {
        for (var i = 0; i < value.Count; i++)
        {
            var permission = await repository.Find(value.ElementAt(i).Id);
            if (permission is not null) continue;
            context.AddFailure($"El permiso: {value.ElementAt(i).Id} no es valido");
        }
        
        return true;
    }

}