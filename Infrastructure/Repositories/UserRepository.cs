using Domain.Entities;
using Domain.Exceptions.User;
using Domain.Repositories;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(MariaDbContext context) : IUserRepository
{
    public async Task<User> CreateUser(User user)
    {
        if (context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == user.Username) is null)
            throw new DuplicatedUsernameException(user.Username);
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        await context.Users
            .AddAsync(user);

        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User> SignIn(string userName, string password)
    {
        var user = await context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Username == userName);

        if (user is null) throw new UserNotFoundException(userName);

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) throw new WrongPasswordException();

        return user;
    }

    public async Task<User?> Find(int id)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> Find(Guid guid)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Guid == guid);
    }
}