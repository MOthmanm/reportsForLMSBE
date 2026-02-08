using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول تسجيل نتائج اختبارات اللياقة البدنية للطلبة على مستوى المادة والمحاضرة
/// </summary>
public class StudentFitnessTestResult : BaseTable
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
    /// معرف المادة
    /// </summary>
    [Required]
    public int CourseId { get; set; }

    /// <summary>
    /// معرف المحاضرة داخل المادة
    /// </summary>
    [Required]
    public int CourseSectionMeetingId { get; set; }

    /// <summary>
    /// معرف تسجيل الطالب في مجموعة المادة
    /// </summary>
    [Required]
    public int StudentCourseEnrollmentId { get; set; }

    /// <summary>
    /// معرف سطر تقسيم الدرجات الخاص باختبار اللياقة
    /// </summary>
    [Required]
    public int DegreeDivisionId { get; set; }

    /// <summary>
    /// معرف التمرين
    /// </summary>
    [Required]
    public int ExerciseId { get; set; }

    /// <summary>
    /// معرف المرحلة السنية المستخدمة في التقييم
    /// </summary>
    public int? AgeStageId { get; set; }

    /// <summary>
    /// معرف شريحة التقييم المرجعية (اختياري)
    /// </summary>
    public int? EvaluationId { get; set; }

    /// <summary>
    /// رقم المحاولة لنفس التمرين في نفس المحاضرة
    /// </summary>
    [Required]
    public short AttemptNo { get; set; } = 1;

    /// <summary>
    /// تاريخ ووقت تنفيذ الاختبار
    /// </summary>
    [Required]
    public DateTime TestDatetime { get; set; } = DateTime.Now;

    /// <summary>
    /// القيمة المنفذة في الاختبار (عدد/زمن/مسافة حسب التمرين)
    /// </summary>
    [Required]
    public decimal PerformedValue { get; set; }

    /// <summary>
    /// الدرجة المستحقة من الاختبار
    /// </summary>
    public decimal? AchievedDegree { get; set; }

    /// <summary>
    /// النسبة المئوية المستحقة
    /// </summary>
    public decimal? AchievedPercentage { get; set; }

    /// <summary>
    /// هل الطالب غائب في هذا الاختبار
    /// </summary>
    public bool IsAbsent { get; set; } = false;

    /// <summary>
    /// ملاحظات إضافية على نتيجة الاختبار
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// هل السجل مفعل
    /// </summary>
    public bool IsActive { get; set; } = true;

    public virtual University? University { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }
    public virtual Course? Course { get; set; }
    public virtual CourseSectionMeeting? CourseSectionMeeting { get; set; }
    public virtual StudentCourseEnrollment? StudentCourseEnrollment { get; set; }
    public virtual LookupCourseDegreeDevision? DegreeDivision { get; set; }
    public virtual LookupFitnessExercise? Exercise { get; set; }
    public virtual LookupFitnessAgeStage? AgeStage { get; set; }
    public virtual LookupFitnessExerciseEvaluation? Evaluation { get; set; }
}

