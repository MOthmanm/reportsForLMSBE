using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الرتب العسكرية
/// </summary>
public class LookupMilitaryRank : BaseTable
{
    public string Code { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public int SortOrder { get; set; }

    public bool IsActive { get; set; } = true;
}

