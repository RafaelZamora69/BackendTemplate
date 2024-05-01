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

    public async Task AssignPermissions(Role role, List<int> permissions)
    {
        // permissions.ForEach(id =>
        // {
        //     var permission = context.Permissions
        //         .FirstOrDefault(p => p.Id == id);
        //     
        //     if (permission is null) throw new PermissionNotFoundException(id);
        //     
        //     role.Permissions.Add(permission);
        // });
        
        await context.SaveChangesAsync();
    }
}