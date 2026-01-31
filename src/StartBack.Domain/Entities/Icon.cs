namespace StartBack.Domain.Entities;

public class Icon
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Key { get; set; } = string.Empty; // unique identifier for the icon (e.g., css class or name)
    public string? DisplayName { get; set; }
}


