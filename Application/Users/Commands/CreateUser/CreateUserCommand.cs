using Application.Abstractions.Commands;
using Application.Abstractions.Responses;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    string Name,
    string Surnames,
    string Password,
    string Email,
    string Username
    ) : BaseCommand<CreateUserCommandResponse>;