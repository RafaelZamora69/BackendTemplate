using Application.Abstractions.Responses;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository) 
    : IRequestHandler<CreateUserCommand, Response<CreateUserCommandResponse>>
{
    public async Task<Response<CreateUserCommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Guid = Guid.NewGuid(),
            Surnames = request.Surnames,
            Password = request.Password,
            Username = request.Username,
            Email = request.Email,
            Role = await roleRepository.FindRole(request.Role.Id) ?? new Role()
        };

        user = await userRepository.CreateUser(user);

        var response = new CreateUserCommandResponse(
            user.Guid,
            user.Name,
            user.Surnames,
            user.Email,
            user.Username);

        return new Response<CreateUserCommandResponse>(response);
    }
}