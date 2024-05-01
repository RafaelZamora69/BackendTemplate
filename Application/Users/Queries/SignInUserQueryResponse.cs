
namespace Application.Users.Queries;

public record SignInUserQueryResponse(
    Guid guid,
    string name,
    string surnames,
    string email,
    string username,
    string token
    );