namespace StartBack.Domain.Entities;

public class MenuItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Key { get; set; } = string.Empty; // unique key
    public string Title { get; set; } = string.Empty; // legacy single title
    public string? TitleEn { get; set; }
    public string? TitleAr { get; set; }
    public string? Url { get; set; }
    public Guid? ParentId { get; set; }
    public int Order { get; set; }
    public Guid? IconId { get; set; }
    public Icon? Icon { get; set; }

    public List<Permission> RequiredPermissions { get; set; } = new();
}

