using StartBack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Entities.Models.Tables;

namespace StartBack.Infrastructure.Persistence;

public class AemzDbContext : DbContext
{
    public AemzDbContext(DbContextOptions<AemzDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Icon> Icons => Set<Icon>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<ReportColumn> ReportColumns => Set<ReportColumn>();
    public DbSet<ReportParameter> ReportParameters => Set<ReportParameter>();
    public DbSet<Assignment> Assignments => Set<Assignment>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AemzDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Username).HasMaxLength(100).IsRequired();
            e.Property(x => x.DisplayName).HasMaxLength(200).IsRequired();
            e.Property(x => x.ProfileImageUrl).HasMaxLength(300);
            e.HasMany(x => x.Roles).WithMany();
            // removed Branches relation
        });

        modelBuilder.Entity<Role>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            e.Property(x => x.DefaultPageUrl).HasMaxLength(200);
            e.HasMany(x => x.Permissions).WithMany();
        });

        modelBuilder.Entity<Permission>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Code).HasMaxLength(200).IsRequired();
            e.Property(x => x.Name).HasMaxLength(200).IsRequired();
            e.HasIndex(x => x.Code).IsUnique();
        });

        // Branch entity removed

        modelBuilder.Entity<MenuItem>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Key).HasMaxLength(100).IsRequired();
            e.Property(x => x.Title).HasMaxLength(200).IsRequired();
            e.HasIndex(x => x.Key).IsUnique();
            e.HasMany<MenuItem>()
                .WithOne()
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasMany(x => x.RequiredPermissions).WithMany();
            e.HasOne(x => x.Icon)
                .WithMany()
                .HasForeignKey(x => x.IconId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Icon>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Key).HasMaxLength(100).IsRequired();
            e.Property(x => x.DisplayName).HasMaxLength(200);
            e.HasIndex(x => x.Key).IsUnique();
        });

        modelBuilder.Entity<RefreshToken>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Token).HasMaxLength(512).IsRequired();
            e.HasIndex(x => x.Token).IsUnique();
            e.HasIndex(x => x.UserId);
        });
    }
}

