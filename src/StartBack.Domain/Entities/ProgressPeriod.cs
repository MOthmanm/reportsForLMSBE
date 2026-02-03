using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول فترات التقدم والتقييم المستمر
/// </summary>
public class ProgressPeriod : BaseTable
{
    /// <summary>
    /// معرّف الربع
    /// </summary>
    public int QuarterId { get; set; }
    public virtual Quarter? Quarter { get; set; }

    /// <summary>
    /// عنوان الفترة
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
    /// هل تحسب درجات
    /// </summary>
    public bool DoesGrades { get; set; } = true;

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }
}
