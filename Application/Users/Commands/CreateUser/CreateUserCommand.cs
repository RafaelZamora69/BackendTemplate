using Application.Abstractions.Responses;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string Name,
    string Surnames,
    string Password,
    string Email,
    string Username
    ) : IRequest<Response<CreateUserCommandResponse>>;