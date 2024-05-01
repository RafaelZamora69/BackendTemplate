using Application.Abstractions.Responses;
using Application.Roles.Commands.CreateRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class RolesController : BaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<Response<CreateRoleCommandResponse>> Create([FromBody] CreateRoleCommand command)
    {

        var response = await Mediator.Send(command);

        return response;
    }
}