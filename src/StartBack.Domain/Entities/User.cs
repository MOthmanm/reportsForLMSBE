namespace StartBack.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // Placeholder for demo
    public bool IsActive { get; set; } = true;
    public string? ProfileImageUrl { get; set; }

    public List<Role> Roles { get; set; } = new();
}


