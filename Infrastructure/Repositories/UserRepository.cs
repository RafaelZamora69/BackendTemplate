using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataContext;

namespace Infrastructure.Repositories;

public class UserRepository(MariaDbContext context) : IUserRepository
{
    public async Task<User> CreateUser(User user)
    {

        await context.Users
            .AddAsync(user);

        await context.SaveChangesAsync();

        return user;
    }
}