using Domain.Entities;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Roles.Validations;

public class RoleMustExistsValidator<T>(IRoleRepository repository) : AsyncPropertyValidator<T, Role>
{
    
    public override string Name { get; }
    
    public override async Task<bool> IsValidAsync(ValidationContext<T> context, Role value, CancellationToken cancellation)
    {
        var role = await repository.FindRole(value.Id);

        if (role is null) context.AddFailure("Este rol no existe.");
        
        return true;
    }

}