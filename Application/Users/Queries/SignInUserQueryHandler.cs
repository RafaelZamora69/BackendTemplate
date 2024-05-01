using Application.Abstractions.Responses;
using Domain.Repositories;
using Infrastructure.Auth;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Users.Queries;

internal sealed class SignInUserQueryHandler(IUserRepository repository, IConfiguration configuration)
    : IRequestHandler<SignInUserQuery, Response<SignInUserQueryResponse>>
{
    public async Task<Response<SignInUserQueryResponse>> Handle(SignInUserQuery request, CancellationToken cancellationToken)
    {
        var user =  await repository.SignIn(request.Username, request.Password);

        var response = new SignInUserQueryResponse(
            user.Guid,
            user.Name,
            user.Surnames,
            user.Email,
            user.Username,
            new JwtManager(configuration).CreateToken(user)
        );

        return new Response<SignInUserQueryResponse>(response);
    }
}