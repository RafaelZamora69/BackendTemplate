using System.Text;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presentation.Middlewares;
using Presentation.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MariaDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MariaDbConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.ConfigureAuthentication(builder);
builder.Services.ConfigureDependencyInjectionContainer();
builder.Services.ConfigureMediatR();
builder.Services.ConfigureValidators();

builder.Services.AddControllers();

var app = builder.Build();

app.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();
// Middlewares
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
if (app.Environment.IsProduction())
{
    app.UseMiddleware<CustomExceptionHandlingMiddleware>();
}

app.Run();
