using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول تعريف المراحل السنية لاختبارات اللياقة البدنية
/// </summary>
public class LookupFitnessAgeStage : BaseTable
{
    /// <summary>
    /// كود المرحلة السنية (فريد)
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string Code { get; set; } = null!;

    /// <summary>
    /// اسم المرحلة السنية بالعربية
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string TitleAr { get; set; } = null!;

    /// <summary>
    /// اسم المرحلة السنية بالإنجليزية
    /// </summary>
    [MaxLength(200)]
    public string? TitleEn { get; set; }

    /// <summary>
    /// العمر الأدنى للمرحلة السنية
    /// </summary>
    [Required]
    public short MinAge { get; set; }

    /// <summary>
    /// العمر الأقصى للمرحلة السنية
    /// </summary>
    [Required]
    public short MaxAge { get; set; }

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int? SortOrder { get; set; }

    /// <summary>
    /// هل المرحلة السنية مفعلة
    /// </summary>
    public bool IsActive { get; set; } = true;

    public virtual ICollection<LookupFitnessExerciseEvaluation> ExerciseEvaluations { get; set; } = new List<LookupFitnessExerciseEvaluation>();
    public virtual ICollection<StudentFitnessTestResult> StudentFitnessTestResults { get; set; } = new List<StudentFitnessTestResult>();
}

