using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول حالات السجلات العامة
/// </summary>
public class LookupRecordStatus : BaseTable
{
    /// <summary>
    /// الرمز
    /// </summary>
    [Required]
    [MaxLength(20)]
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
    /// الوصف
    /// </summary>
    [MaxLength(255)]
    public string? Description { get; set; }

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsActive { get; set; } = true;
}
