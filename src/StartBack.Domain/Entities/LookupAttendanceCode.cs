using Entities.Models.BaseTables;
using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول أكواد الحضور
/// </summary>
public class LookupAttendanceCode : BaseTable
{
    /// <summary>
    /// الرمز
    /// </summary>
    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    /// <summary>
    /// الاسم بالعربية
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string NameAr { get; set; } = null!;

    /// <summary>
    /// الاسم بالإنجليزية
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string NameEn { get; set; } = null!;

    /// <summary>
    /// الاسم المختصر
    /// </summary>
    [MaxLength(10)]
    public string? ShortName { get; set; }

    /// <summary>
    /// نوع الحضور
    /// </summary>
    public AttendanceType Type { get; set; }

    /// <summary>
    /// نقاط الخصم
    /// </summary>
    public decimal DeductionPoints { get; set; }

    /// <summary>
    /// لون العرض
    /// </summary>
    [MaxLength(10)]
    public string? ColorCode { get; set; }

    /// <summary>
    /// افتراضي
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// هل يعتبر حضور
    /// </summary>
    public bool IsPresence { get; set; } = false;

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsActive { get; set; } = true;
}
