namespace StartBack.Domain.Entities;

public class Role
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? DefaultPageUrl { get; set; } // الصفحة الافتراضية التي يدخل عليها المستخدم عند تسجيل الدخول
    public List<Permission> Permissions { get; set; } = new();
}


