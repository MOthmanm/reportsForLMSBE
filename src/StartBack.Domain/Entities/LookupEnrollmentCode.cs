using Entities.Models.BaseTables;
using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول أكواد القيد (دخول/خروج)
/// </summary>
public class LookupEnrollmentCode : BaseTable
{
    public string Code { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    public string NameEn { get; set; } = null!;
    public int SortOrder { get; set; }

}
