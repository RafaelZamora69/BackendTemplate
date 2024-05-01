using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Setup;

public static class MigrationsSetup
{

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();

        var mariaDB = scope.ServiceProvider.GetRequiredService<MariaDbContext>();
        mariaDB.Database.Migrate();
    }
    
}