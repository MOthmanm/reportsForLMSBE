using StartBack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Persistence;

public static class DbSeeder
{
    public static async Task SeedAsync(AemzDbContext db, CancellationToken ct = default)
    {
        await db.Database.MigrateAsync(ct);

        // 1) Upsert core permissions (screens/actions)
        // Keep legacy View and CRUD Read/Create/Update/Delete/Export
        var permCodes = new (string Code, string Name)[]
        {
            // Legacy View
            ("Users.View", "Users View"),
            // ("Branches.View", "Branches View") removed
            ("Roles.View", "Roles View"),
            ("Permissions.View", "Permissions View"),

            // CRUD
            ("Users.Read", "Users Read"),
            ("Users.Create", "Users Create"),
            ("Users.Update", "Users Update"),
            ("Users.Delete", "Users Delete"),

            ("Roles.Read", "Roles Read"),
            ("Roles.Create", "Roles Create"),
            ("Roles.Update", "Roles Update"),
            ("Roles.Delete", "Roles Delete"),

            ("Permissions.Read", "Permissions Read"),
            ("Permissions.Create", "Permissions Create"),
            ("Permissions.Update", "Permissions Update"),
            ("Permissions.Delete", "Permissions Delete"),
            // Branches CRUD removed

            ("Menus.Read", "Menus Read"),
            ("Menus.Create", "Menus Create"),
            ("Menus.Update", "Menus Update"),
            ("Menus.Delete", "Menus Delete"),

            // Export permissions
            ("Users.Export", "Users Export"),
            ("Roles.Export", "Roles Export"),
            ("Permissions.Export", "Permissions Export"),
            ("Menus.Export", "Menus Export")
        };

        foreach (var (code, name) in permCodes)
        {
            var p = await db.Permissions.FirstOrDefaultAsync(x => x.Code == code, ct);
            if (p == null)
            {
                await db.Permissions.AddAsync(new Permission { Code = code, Name = name }, ct);
            }
            else if (p.Name != name)
            {
                p.Name = name; // keep names updated
            }
        }
        await db.SaveChangesAsync(ct);

        // 5) Seed Icons keys supported by frontend
        var iconKeys = new string[]
        {
            // dual.*
            "dual.alarm","dual.applications","dual.components","dual.elements","dual.forms","dual.lamp","dual.logo","dual.prototypes","dual.search","dual.stats-up","dual.table","dual.vertical-slider",
            // nav.*
            "nav.accordion","nav.alert","nav.attachment","nav.attributions","nav.avatar","nav.badge","nav.bank-build","nav.bot","nav.box-add","nav.btc","nav.button","nav.calendar","nav.changelogs","nav.chart","nav.chat","nav.check-double","nav.checkbox","nav.circlebar","nav.cloud","nav.collapse","nav.currency-dollar","nav.divider","nav.doc","nav.document-add","nav.document","nav.drawer","nav.dropdown","nav.error","nav.getting-started","nav.hooks","nav.id","nav.info","nav.input-group","nav.input-mask","nav.input","nav.invoice","nav.kanban","nav.list","nav.login","nav.mail","nav.map","nav.mask","nav.megaphone","nav.menu-list","nav.modal","nav.money","nav.monitor","nav.nft-1","nav.nft-2","nav.notification","nav.onboarding","nav.order-timer","nav.pagination","nav.people-edit","nav.people-monitor","nav.people-plus","nav.people","nav.personal-chart","nav.pin","nav.placeload","nav.popover","nav.progress","nav.project-board","nav.question","nav.radio","nav.range","nav.scroll","nav.select","nav.shared-components","nav.shopping-cart","nav.spinner","nav.statistic-2","nav.statistic","nav.steps","nav.stethoscope","nav.student","nav.swap","nav.switch","nav.tab","nav.table-2","nav.table-3","nav.table","nav.tag","nav.teacher","nav.textarea","nav.timeline","nav.treeview","nav.truck","nav.typography","nav.user","nav.utility","nav.validation","nav.widget","nav.window",
            // internal
            "dashboards","settings","dashboards.home","settings.general","settings.appearance"
        };
        foreach (var key in iconKeys)
        {
            if (!await db.Icons.AnyAsync(i => i.Key == key, ct))
            {
                await db.Icons.AddAsync(new Icon { Key = key, DisplayName = key }, ct);
            }
        }
        await db.SaveChangesAsync(ct);
        // 2) Upsert roles and attach permissions
        async Task<Role> UpsertRoleAsync(string name, IEnumerable<string> requiredPermCodes)
        {
            var role = await db.Roles.Include(r => r.Permissions).FirstOrDefaultAsync(r => r.Name == name, ct);
            if (role == null)
            {
                role = new Role { Name = name };
                await db.Roles.AddAsync(role, ct);
            }
            var perms = await db.Permissions.Where(p => requiredPermCodes.Contains(p.Code)).ToListAsync(ct);
            foreach (var pr in perms)
            {
                if (!role.Permissions.Any(x => x.Id == pr.Id)) role.Permissions.Add(pr);
            }
            return role;
        }

        // Admin: grant all permissions (legacy + CRUD + Export)
        var adminRole = await UpsertRoleAsync("Admin", permCodes.Select(x => x.Code));
        adminRole.DefaultPageUrl = "/admin-dashboard"; // لوحة تحكم المدير

        // Manager: read-only for Users (legacy + CRUD-read + Export)
        var managerRole = await UpsertRoleAsync("Manager", new[] { "Users.View", "Users.Read", "Users.Export" });
        managerRole.DefaultPageUrl = "/manager-dashboard"; // لوحة تحكم المدير الفرعي
        await db.SaveChangesAsync(ct);

        // 2.b) Transitional mapping: ensure CRUD codes are granted where legacy View exists on ANY role
        var resourceNames = new[] { "Users", "Roles", "Permissions", "Menus" };
        var allPerms = await db.Permissions.ToListAsync(ct);
        foreach (var role in await db.Roles.Include(r => r.Permissions).ToListAsync(ct))
        {
            var codes = role.Permissions.Select(p => p.Code).ToHashSet();
            foreach (var res in resourceNames)
            {
                if (codes.Contains($"{res}.View") && !codes.Contains($"{res}.Read"))
                {
                    var read = allPerms.FirstOrDefault(p => p.Code == $"{res}.Read");
                    if (read != null) role.Permissions.Add(read);
                }

            }
        }
        await db.SaveChangesAsync(ct);

        // 3) Seed default users if not present (branches removed)
        if (!await db.Users.AnyAsync(ct))
        {
            var u1 = new User { Username = "admin", DisplayName = "System Admin", PasswordHash = "admin", Roles = new() { adminRole } };
            var u2 = new User { Username = "manager1", DisplayName = "Branch Manager", PasswordHash = "1234", Roles = new() { managerRole } };
            await db.Users.AddRangeAsync(new[] { u1, u2 }, ct);
            await db.SaveChangesAsync(ct);
        }

        // 4) Upsert Menu (screens) so any machine gets all screens on startup
        async Task<MenuItem> UpsertMenuAsync(string key, string title, string? url, Guid? parentId, int order, string[] requiredPermCodes, string? iconKey = null, string? titleEn = null, string? titleAr = null)
        {
            var mi = await db.MenuItems.Include(m => m.RequiredPermissions).FirstOrDefaultAsync(m => m.Key == key, ct);
            var perms = await db.Permissions.Where(p => requiredPermCodes.Contains(p.Code)).ToListAsync(ct);
            if (mi == null)
            {
                Guid? iconId = null;
                if (!string.IsNullOrWhiteSpace(iconKey))
                {
                    var icon = await db.Icons.FirstOrDefaultAsync(i => i.Key == iconKey, ct);
                    iconId = icon?.Id;
                }
                mi = new MenuItem { Key = key, Title = title, TitleEn = titleEn ?? title, TitleAr = titleAr ?? title, Url = url, ParentId = parentId, Order = order, RequiredPermissions = perms, IconId = iconId };
                await db.MenuItems.AddAsync(mi, ct);
            }
            else
            {
                mi.Title = title; mi.TitleEn = titleEn ?? mi.TitleEn ?? title; mi.TitleAr = titleAr ?? mi.TitleAr ?? title; mi.Url = url; mi.ParentId = parentId; mi.Order = order;
                if (!string.IsNullOrWhiteSpace(iconKey))
                {
                    var icon = await db.Icons.FirstOrDefaultAsync(i => i.Key == iconKey, ct);
                    mi.IconId = icon?.Id;
                }
                mi.RequiredPermissions.Clear();
                foreach (var p in perms) mi.RequiredPermissions.Add(p);
            }
            return mi;
        }

        // Root
        var root = await UpsertMenuAsync("setup", "Setup", null, null, 1, Array.Empty<string>(), "nav.menu-list", "Setup", "الإعدادات");
        await db.SaveChangesAsync(ct); // ensure root has Id

        // Dashboard pages
        await UpsertMenuAsync("admin-dashboard", "Admin Dashboard", "/admin-dashboard", null, 0, new[] { "Users.Read" }, "dashboards.home", "Admin Dashboard", "لوحة المدير");
        await UpsertMenuAsync("manager-dashboard", "Manager Dashboard", "/manager-dashboard", null, 0, new[] { "Users.View" }, "dashboards", "Manager Dashboard", "لوحة المدير الفرعي");

        // Children screens (Users, Roles, Permissions, Menus) -> use CRUD Read codes for visibility
        await UpsertMenuAsync("users", "Users", "/users", root.Id, 1, new[] { "Users.Read" }, "nav.user", "Users", "المستخدمون");
        await UpsertMenuAsync("roles", "Roles", "/roles", root.Id, 3, new[] { "Roles.Read" }, "nav.people", "Roles", "الأدوار");
        await UpsertMenuAsync("permissions", "Permissions", "/permissions", root.Id, 4, new[] { "Permissions.Read" }, "nav.validation", "Permissions", "الصلاحيات");
        await UpsertMenuAsync("menus", "Menus", "/menus", root.Id, 5, new[] { "Menus.Read" }, "nav.menu-list", "Menus", "القوائم");
        await db.SaveChangesAsync(ct);


    }
}



