using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول درجات التكليفات (دفتر الدرجات)
/// </summary>
public class AssignmentGrade : BaseTable
{
    /// <summary>
    /// معرّف التكليف
    /// </summary>
    public int AssignmentId { get; set; }
    public virtual Assignment? Assignment { get; set; }

    /// <summary>
    /// معرّف علاقة الطالب بالجامعة
    /// </summary>
    public int PersonUniversityId { get; set; }
    public virtual PersonUniversity? PersonUniversity { get; set; }

    /// <summary>
    /// النقاط المكتسبة
    /// </summary>
    public decimal? PointsEarned { get; set; }

    /// <summary>
    /// التقدير
    /// </summary>
    [MaxLength(5)]
    public string? LetterGrade { get; set; }

    /// <summary>
    /// معذور
    /// </summary>
    public bool IsExcused { get; set; } = false;

    /// <summary>
    /// غير مكتمل
    /// </summary>
    public bool IsIncomplete { get; set; } = false;

    /// <summary>
    /// متأخر
    /// </summary>
    public bool IsLate { get; set; } = false;

    /// <summary>
    /// تعليق
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// تم التقييم بواسطة
    /// </summary>
    public int? GradedBy { get; set; }

    /// <summary>
    /// تم التقييم في
    /// </summary>
    public DateTime? GradedAt { get; set; }
}
