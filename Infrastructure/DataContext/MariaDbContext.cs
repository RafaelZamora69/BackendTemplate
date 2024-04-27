using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public class MariaDbContext(DbContextOptions<MariaDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}