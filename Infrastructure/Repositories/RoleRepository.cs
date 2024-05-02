using Domain.Entities;
using Domain.Exceptions.Permission;
using Domain.Repositories;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoleRepository(MariaDbContext context) : IRoleRepository
{
    public async Task<Role> CreateRole(Role role)
    {
        await context.Roles.AddAsync(role);

        await context.SaveChangesAsync();

        return role;
    }

    public async Task AssignPermissions(Role role, List<int> permissionsId)
    {
        var permissions =  context.Permissions
            .Where(p => permissionsId.Any(id => p.Id == id));

        foreach (var permission in permissions)
        {
            role.Permissions.Add(permission);
        }

        await context.SaveChangesAsync();
    }
}