using Application.Abstractions.Commands;

namespace Application.Roles.Commands.CreateRole;

public record CreateRoleCommand(
    string name,
    List<CreateRoleCommandPermission> permissions
    ) : BaseCommand<CreateRoleCommandResponse>;

public struct CreateRoleCommandPermission
{
    public int Id { get; set; }
}