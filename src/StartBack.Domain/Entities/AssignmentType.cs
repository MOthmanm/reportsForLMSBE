using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول أنواع التكليفات والواجبات
/// </summary>
public class AssignmentType : BaseTable
{
    /// <summary>
    /// معرّف حصة المقرر
    /// </summary>
    public int CourseSectionId { get; set; }
    public virtual CourseSemester? CourseSection { get; set; }

    /// <summary>
    /// عنوان النوع
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// النسبة المئوية
    /// </summary>
    public decimal? WeightPercent { get; set; }

    /// <summary>
    /// النقاط الافتراضية
    /// </summary>
    public decimal? DefaultPoints { get; set; }

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }
}
