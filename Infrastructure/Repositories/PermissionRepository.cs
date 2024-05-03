using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PermissionRepository(MariaDbContext context) : IPermissionRepository
{
    public bool UserHasPermission(string code, User user)
    {
        return context.Permissions
            .FromSqlRaw($"Select t1.* " +
                        $"From Permissions t1 " +
                        $"  Inner Join PermissionRole t2 " +
                        $"     On t2.PermissionsId = t1.Id " +
                        $"  Inner Join Roles t3 " +
                        $"     On t3.Id = t2.RolesId " +
                        $"  Inner Join Users t4 " +
                        $"     On t4.Id = {user.Id} " +
                        $"Where t1.Code = '{code}'")
            .ToList()
            .Count > 0;
    }
    
    public async Task<Permission?> Find(int id)
    {
        return await context.Permissions
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}