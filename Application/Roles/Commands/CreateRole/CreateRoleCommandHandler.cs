using Application.Abstractions.Responses;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler(IRoleRepository roleRepository)
    : IRequestHandler<CreateRoleCommand, Response<CreateRoleCommandResponse>>
{
    public async Task<Response<CreateRoleCommandResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role()
        {
            Name = request.name
        };

        role = await roleRepository.CreateRole(role);

        var permissions = request.permissions
            .Select(p => p.Id)
            .ToList();
        await roleRepository.AssignPermissions(role, permissions);

        var response = new CreateRoleCommandResponse(role.Id, role.Name);
        return new Response<CreateRoleCommandResponse>(response);
    }
}