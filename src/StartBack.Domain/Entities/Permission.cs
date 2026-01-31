namespace StartBack.Domain.Entities;

public class Permission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = string.Empty; // e.g., Users.View
    public string Name { get; set; } = string.Empty; // Arabic/English label
}


