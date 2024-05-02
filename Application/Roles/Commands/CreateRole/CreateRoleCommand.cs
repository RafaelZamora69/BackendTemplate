using Application.Abstractions.Commands;
using Domain.Entities;

namespace Application.Roles.Commands.CreateRole;

public record CreateRoleCommand(
    string name,
    List<Permission> permissions
    ) : BaseCommand<CreateRoleCommandResponse>;