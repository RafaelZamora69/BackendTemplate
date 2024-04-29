using Application.Abstractions.Responses;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandHandler(
    IUserRepository userRepository
    ) : IRequestHandler<CreateUserCommand, Response<User>>
{
    public async Task<Response<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Password = request.Password
        };

        user = await userRepository.CreateUser(user);

        return new Response<User>(user);
    }
}