using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
}