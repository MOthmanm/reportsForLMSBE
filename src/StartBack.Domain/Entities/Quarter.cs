using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الأرباع الدراسية
/// </summary>
public class Quarter : BaseTable
{
    /// <summary>
    /// معرّف الفصل الدراسي
    /// </summary>
    public int SemesterId { get; set; }
    public virtual Semester? Semester { get; set; }

    /// <summary>
    /// عنوان الربع
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// الاسم المختصر
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string ShortName { get; set; } = null!;

    /// <summary>
    /// تاريخ البداية
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// تاريخ النهاية
    /// </summary>
    public DateOnly EndDate { get; set; }

    /// <summary>
    /// تاريخ بدء الرصد
    /// </summary>
    public DateOnly? PostStartDate { get; set; }

    /// <summary>
    /// تاريخ انتهاء الرصد
    /// </summary>
    public DateOnly? PostEndDate { get; set; }

    /// <summary>
    /// هل يحسب درجات
    /// </summary>
    public bool DoesGrades { get; set; } = true;

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }
}
