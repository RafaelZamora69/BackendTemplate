namespace Application.Users.Commands.CreateUser;

public record CreateUserCommandResponse(
    Guid guid,
    string name,
    string surnames,
    string? email,
    string username
    );