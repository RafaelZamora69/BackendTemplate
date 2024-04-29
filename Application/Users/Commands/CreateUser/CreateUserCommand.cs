using Application.Abstractions.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string Name,
    string Password
    ) : IRequest<Response<User>>;