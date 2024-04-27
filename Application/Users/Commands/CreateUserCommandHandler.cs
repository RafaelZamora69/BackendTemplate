using Domain.Repositories;
using MediatR;

namespace Application.Users.Commands;

internal sealed class CreateUserCommandHandler(
    IUserRepository userRepository
    ) : IRequestHandler<CreateUserCommand>
{
    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        
        throw new NotImplementedException();
    }
}