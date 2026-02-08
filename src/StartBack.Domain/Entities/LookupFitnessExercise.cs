using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول تعريف تمارين اختبار اللياقة البدنية
/// </summary>
public class LookupFitnessExercise : BaseTable
{
    /// <summary>
    /// معرف سطر تقسيم الدرجات (اختبار اللياقة) من جدول degree-divisions
    /// </summary>
    [Required]
    public int DegreeDivisionId { get; set; }

    /// <summary>
    /// كود التمرين (فريد داخل نفس سطر تقسيم الدرجات)
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string Code { get; set; } = null!;

    /// <summary>
    /// اسم التمرين بالعربية
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string TitleAr { get; set; } = null!;

    /// <summary>
    /// اسم التمرين بالإنجليزية
    /// </summary>
    [MaxLength(200)]
    public string? TitleEn { get; set; }

    /// <summary>
    /// وحدة القياس بالعربية (مثال: عدة/ثانية/متر)
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string UnitNameAr { get; set; } = "عدة";

    /// <summary>
    /// وحدة القياس بالإنجليزية
    /// </summary>
    [MaxLength(50)]
    public string? UnitNameEn { get; set; }

    /// <summary>
    /// الدرجة القصوى للتمرين
    /// </summary>
    public decimal? MaxDegree { get; set; }

    /// <summary>
    /// وصف إضافي للتمرين
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int? SortOrder { get; set; }

    /// <summary>
    /// هل التمرين مفعل
    /// </summary>
    public bool IsActive { get; set; } = true;

    public virtual LookupCourseDegreeDevision? DegreeDivision { get; set; }
    public virtual ICollection<LookupFitnessExerciseEvaluation> ExerciseEvaluations { get; set; } = new List<LookupFitnessExerciseEvaluation>();
    public virtual ICollection<StudentFitnessTestResult> StudentFitnessTestResults { get; set; } = new List<StudentFitnessTestResult>();
}

