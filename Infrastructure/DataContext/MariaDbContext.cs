using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public class MariaDbContext : DbContext
{
    public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options) { }
    
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    
}