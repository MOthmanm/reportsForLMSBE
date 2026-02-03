using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول المتطلبات السابقة للمقررات
/// </summary>
public class CoursePrerequisite : BaseTable
{
    /// <summary>
    /// معرّف المقرر
    /// </summary>
    public int CourseId { get; set; }
    public virtual Course? Course { get; set; }

    /// <summary>
    /// معرّف المقرر السابق المطلوب
    /// </summary>
    public int PrerequisiteCourseId { get; set; }
    public virtual Course? PrerequisiteCourse { get; set; }

    /// <summary>
    /// هل المتطلب إجباري
    /// </summary>
    public bool IsMandatory { get; set; } = true;

    /// <summary>
    /// الحد الأدنى للتقدير المطلوب
    /// </summary>
    [MaxLength(10)]
    public string? MinGrade { get; set; }

    /// <summary>
    /// ملاحظات
    /// </summary>
    public string? Notes { get; set; }
}
