using Application.Abstractions.Responses;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class UsersController : BaseController
{
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<Response<SignInUserQueryResponse>> SignIn([FromBody] SignInUserQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpPost]
    public async Task<Response<CreateUserCommandResponse>> Register([FromBody] CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
    
}