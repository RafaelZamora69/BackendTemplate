using Application.Abstractions.Responses;
using MediatR;

namespace Application.Users.Queries;

public record SignInUserQuery(
    string Username,
    string Password
    ) : IRequest<Response<SignInUserQueryResponse>>;