using Domain.Entities;

namespace Domain.Repositories;

public interface IPermissionRepository
{

    Task<Permission?> Find(int id);

}