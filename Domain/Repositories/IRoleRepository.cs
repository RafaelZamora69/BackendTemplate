using Domain.Entities;

namespace Domain.Repositories;

public interface IRoleRepository
{
    Task<Role> CreateRole(Role role);
    Task AssignPermissions(Role role, List<int> permissionsId);
    Task<Role?> FindRole(int id);
}