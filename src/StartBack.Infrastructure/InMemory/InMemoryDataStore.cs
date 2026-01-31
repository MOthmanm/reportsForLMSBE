using StartBack.Domain.Entities;

namespace StartBack.Infrastructure.InMemory;

public class InMemoryDataStore
{
    public List<User> Users { get; } = new();
    public List<Role> Roles { get; } = new();
    public List<Permission> Permissions { get; } = new();
    public List<MenuItem> Menu { get; } = new();
    public List<RefreshToken> RefreshTokens { get; } = new();

    public InMemoryDataStore()
    {
        // Seed permissions
        var permUsersView = new Permission { Code = "Users.View", Name = "Users View" };
        var permUsersExport = new Permission { Code = "Users.Export", Name = "Users Export" };
        // branches removed
        var permRolesExport = new Permission { Code = "Roles.Export", Name = "Roles Export" };
        var permPermissionsExport = new Permission { Code = "Permissions.Export", Name = "Permissions Export" };
        var permMenusExport = new Permission { Code = "Menus.Export", Name = "Menus Export" };
        Permissions.AddRange(new[] { permUsersView, permUsersExport, permRolesExport, permPermissionsExport, permMenusExport });

        // Seed roles
        var adminRole = new Role { Name = "Admin", DefaultPageUrl = "/admin-dashboard", Permissions = new() { permUsersView, permUsersExport, permRolesExport, permPermissionsExport, permMenusExport } };
        var managerRole = new Role { Name = "Manager", DefaultPageUrl = "/manager-dashboard", Permissions = new() { permUsersView, permUsersExport } };
        Roles.AddRange(new[] { adminRole, managerRole });

        // Seed branches
        // branches removed

        // Seed users
        var u1 = new User { Username = "admin", DisplayName = "System Admin", PasswordHash = "admin", Roles = new() { adminRole } };
        var u2 = new User { Username = "manager1", DisplayName = "Branch Manager", PasswordHash = "1234", Roles = new() { managerRole } };
        Users.AddRange(new[] { u1, u2 });

        // Seed menu (simple tree)
        var mAdminDashboard = new MenuItem { Key = "admin-dashboard", Title = "Admin Dashboard", Url = "/admin-dashboard", Order = 0, RequiredPermissions = new() { permUsersView } };
        var mManagerDashboard = new MenuItem { Key = "manager-dashboard", Title = "Manager Dashboard", Url = "/manager-dashboard", Order = 0, RequiredPermissions = new() { permUsersView } };
        var mRootSetup = new MenuItem { Key = "setup", Title = "Setup", Order = 1 };
        var mUsers = new MenuItem { Key = "users", Title = "Users", Url = "/users", ParentId = mRootSetup.Id, Order = 1, RequiredPermissions = new() { permUsersView } };
        Menu.AddRange(new[] { mAdminDashboard, mManagerDashboard, mRootSetup, mUsers });
    }
}

