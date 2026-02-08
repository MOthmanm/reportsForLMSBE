using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول المعدل التراكمي المحسوب للطلاب
/// </summary>
public class StudentGpa : BaseTable, ITenantEntity
{
    /// <summary>
    /// معرّف علاقة الطالب بالجامعة
    /// </summary>
    public int PersonUniversityId { get; set; }
    public virtual PersonUniversity? PersonUniversity { get; set; }

    /// <summary>
    /// معرّف الجامعة
    /// </summary>
    public int UniversityId { get; set; }
    public virtual University? University { get; set; }

    /// <summary>
    /// معرّف السنة الدراسية
    /// </summary>
    public int AcademicYearId { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }

    /// <summary>
    /// معرّف الفصل الدراسي
    /// </summary>
    public int? SemesterId { get; set; }
    public virtual Semester? Semester { get; set; }

    /// <summary>
    /// المعدل الفصلي
    /// </summary>
    public decimal? Gpa { get; set; }

    /// <summary>
    /// المعدل الموزون
    /// </summary>
    public decimal? WeightedGpa { get; set; }

    /// <summary>
    /// المعدل التراكمي
    /// </summary>
    public decimal? CumulativeGpa { get; set; }

    /// <summary>
    /// المجموع الكلي المكتسب (للفصل أو التراكمي)
    /// </summary>
    public decimal? TotalScore { get; set; }

    /// <summary>
    /// النهاية العظمى للمجموع
    /// </summary>
    public decimal? TotalMaxScore { get; set; }

    /// <summary>
    /// الترتيب الفصلي
    /// </summary>
    public int? SemesterRank { get; set; }

    /// <summary>
    /// ترتيب الدفعة (التراكمي)
    /// </summary>
    public int? BatchRank { get; set; }

    /// <summary>
    /// ترتيب الدفعة (Legacy)
    /// </summary>
    public int? ClassRank { get; set; }

    /// <summary>
    /// عدد الدفعة
    /// </summary>
    public int? ClassSize { get; set; }

    /// <summary>
    /// الساعات المكتسبة
    /// </summary>
    public decimal? CreditsEarned { get; set; }

    /// <summary>
    /// تاريخ الحساب
    /// </summary>
    public DateTime CalculatedAt { get; set; }
}
