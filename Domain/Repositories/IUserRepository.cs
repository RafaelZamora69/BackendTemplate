using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    void CreateUser(User user);
}