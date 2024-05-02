using Application.Abstractions.Attributes;
using Application.Abstractions.Responses;
using Application.Roles.Commands.CreateRole;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class RolesController : BaseController
{
    [HttpPost]
    [Can("users:create")]
    public async Task<Response<CreateRoleCommandResponse>> Create([FromBody] CreateRoleCommand command)
    {

        var response = await Mediator.Send(command);

        return response;
    }
}