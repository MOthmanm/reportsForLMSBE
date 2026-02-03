using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول السجل الأكاديمي (الشهادة الدراسية)
/// </summary>
public class Transcript : BaseTable
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
    /// اسم الجامعة
    /// </summary>
    [MaxLength(200)]
    public string? UniversityName { get; set; }

    /// <summary>
    /// معرّف السنة الدراسية
    /// </summary>
    public int? AcademicYearId { get; set; }

    /// <summary>
    /// عنوان السنة الدراسية
    /// </summary>
    [MaxLength(50)]
    public string? AcademicYearTitle { get; set; }

    /// <summary>
    /// المستوى الأكاديمي
    /// </summary>
    [MaxLength(20)]
    public string? AcademicLevel { get; set; }

    /// <summary>
    /// رمز المقرر
    /// </summary>
    [MaxLength(50)]
    public string? CourseCode { get; set; }

    /// <summary>
    /// اسم المقرر
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string CourseTitle { get; set; } = null!;

    /// <summary>
    /// التقدير
    /// </summary>
    [MaxLength(10)]
    public string? LetterGrade { get; set; }

    /// <summary>
    /// النسبة المئوية
    /// </summary>
    public decimal? GradePercent { get; set; }

    /// <summary>
    /// قيمة المعدل
    /// </summary>
    public decimal? GpaValue { get; set; }

    /// <summary>
    /// الساعات المحاولة
    /// </summary>
    public decimal? CreditsAttempted { get; set; }

    /// <summary>
    /// الساعات المكتسبة
    /// </summary>
    public decimal? CreditsEarned { get; set; }

    /// <summary>
    /// يحسب في المعدل
    /// </summary>
    public bool IncludeInGpa { get; set; } = true;

    /// <summary>
    /// منقول
    /// </summary>
    public bool IsTransfer { get; set; } = false;

    /// <summary>
    /// ملاحظات
    /// </summary>
    public string? Notes { get; set; }
}
