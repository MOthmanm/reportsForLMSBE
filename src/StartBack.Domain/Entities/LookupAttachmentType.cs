using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول أنواع المرفقات
/// </summary>
public class LookupAttachmentType : BaseTable
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
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsActive { get; set; } = true;
}

