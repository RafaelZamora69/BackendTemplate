using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PermissionRepository(MariaDbContext context) : IPermissionRepository
{
    public async Task<Permission?> Find(int id)
    {
        return await context.Permissions
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}