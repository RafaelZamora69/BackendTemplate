using FluentValidation;

namespace Application.Users.Commands.CreateUser;

public class CreateCustomerValidator : AbstractValidator<CreateUserCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre es requerido");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida.");
    }
}