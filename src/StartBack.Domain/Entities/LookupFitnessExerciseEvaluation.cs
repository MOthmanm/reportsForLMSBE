using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول ربط تقييم الدرجة/العدة لكل تمرين حسب المرحلة السنية بالنسبة المئوية
/// </summary>
public class LookupFitnessExerciseEvaluation : BaseTable
{
    /// <summary>
    /// معرف الجامعة
    /// </summary>
    [Required]
    public int UniversityId { get; set; }

    /// <summary>
    /// معرف العام الأكاديمي
    /// </summary>
    [Required]
    public int AcademicYearId { get; set; }

    /// <summary>
    /// معرف المرحلة السنية
    /// </summary>
    [Required]
    public int AgeStageId { get; set; }

    /// <summary>
    /// معرف التمرين
    /// </summary>
    [Required]
    public int ExerciseId { get; set; }

    /// <summary>
    /// الدرجة أو عدد العدات المقابل للتقييم
    /// </summary>
    [Required]
    public decimal DegreeValue { get; set; }

    /// <summary>
    /// النسبة المئوية المقابلة للدرجة
    /// </summary>
    [Required]
    public decimal PercentageValue { get; set; }

    /// <summary>
    /// ترتيب العرض داخل التمرين
    /// </summary>
    public int? SortOrder { get; set; }

    /// <summary>
    /// هل التقييم مفعل
    /// </summary>
    public bool IsActive { get; set; } = true;

    public virtual University? University { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }
    public virtual LookupFitnessAgeStage? AgeStage { get; set; }
    public virtual LookupFitnessExercise? Exercise { get; set; }
    public virtual ICollection<StudentFitnessTestResult> StudentFitnessTestResults { get; set; } = new List<StudentFitnessTestResult>();
}

