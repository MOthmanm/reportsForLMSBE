using StartBack.Application.Abstractions;
using StartBack.Infrastructure.InMemory;
using StartBack.Infrastructure.Ef;
using Microsoft.Extensions.DependencyInjection;
using StartBack.Domain.Interfaces;
using StartBack.Infrastracture.Repositories;
using StartBack.Infrastructure.Interfaces;
using StartBack.Infrastructure.Services;
using StartBack.Infrastructure.Helpers;

namespace StartBack.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    // In-memory demo services
    public static IServiceCollection AddInfrastructureInMemory(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryDataStore>();
        services.AddScoped<IUserService, InMemoryUserService>();
        services.AddScoped<IAuthService, InMemoryAuthService>();
        services.AddScoped<IMenuService, InMemoryMenuService>();
        services.AddScoped<IMenuAdminService, InMemoryMenuAdminService>();
        return services;
    }

    // EF-based services
    public static IServiceCollection AddInfrastructureEf(this IServiceCollection services)
    {
        services.AddScoped<EfUserService>();
        services.AddScoped<IUserService>(sp => sp.GetRequiredService<EfUserService>());
        services.AddScoped<IAuthService, EfAuthService>();
        services.AddScoped<IMenuService, EfMenuService>();
        services.AddScoped<IRoleService, EfRoleService>();
        services.AddScoped<IPermissionService, EfPermissionService>();
        services.AddScoped<IMenuAdminService, EfMenuAdminService>();
        services.AddScoped<IIconService, EfIconService>();

        return services;
    }
}

