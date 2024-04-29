using Application.Abstractions.Responses;
using Application.Users.Commands.CreateUser;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class UserController : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<Response<User>> Register([FromBody] CreateUserCommand command)
    {
        
        var response = await Mediator.Send(command);

        return response;
    }
}