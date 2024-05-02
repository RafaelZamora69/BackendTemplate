using Application.Abstractions.Attributes;
using Application.Abstractions.Commands;
using Domain.Entities;

namespace Application.Users.Commands.CreateUser;

[Can("users:create")]
public record CreateUserCommand(
    string Name,
    string Surnames,
    string Password,
    string Email,
    string Username,
    Role Role
    ) : BaseCommand<CreateUserCommandResponse>;