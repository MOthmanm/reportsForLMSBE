using StartBack.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Migrations;
using StartBack.Infrastructure.Persistence.Repositories;
using StartBack.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StartBack.Domain.Interfaces;
using StartBack.Infrastracture.Repositories;
using StartBack.Infrastructure.Helpers;
using StartBack.Infrastructure.Interfaces;
using StartBack.Infrastructure.Services;
using System.Configuration;

namespace StartBack.Infrastructure.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddSqlServerPersistence(this IServiceCollection services, IConfiguration config)
    {
        var conn = config.GetConnectionString("Default") ?? "Server=localhost;Database=StartBack;Trusted_Connection=True;TrustServerCertificate=True";

        // Register DbContext
        services.AddDbContext<AemzDbContext>(options =>
            options.UseNpgsql(conn)
                   .UseSnakeCaseNamingConvention()
                   .ReplaceService<IHistoryRepository, SnakeCaseHistoryRepository>()
                   .EnableSensitiveDataLogging());

        services.AddScoped<DbContext, AemzDbContext>();
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Register PostgreSqlExecutor with the connection string
        services.AddScoped<PostgreSqlExecutor>(provider => new PostgreSqlExecutor(conn));

        return services;
    }
}