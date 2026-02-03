using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الدرجات النهائية للمقررات
/// </summary>
public class FinalGrade : BaseTable
{

    public decimal? Degree { get; set; }

    /// <summary>
    /// النسبة المئوية
    /// </summary>
    public decimal? GradePercent { get; set; }

    /// <summary>
    /// قيمة المعدل
    /// </summary>
    public decimal? GpaValue { get; set; }

    /// <summary>
    /// التقدير
    /// </summary>
    public string? LetterGrade { get; set; } // بجيبه من الكورس ومنه بجيب التقدير عبر grade scale item

    public int StudentCourseEnrollmentId { get; set; }
    public int CourseSemesterId { get; set; }
    public int SemesterId { get; set; }
    public virtual int? GradeScaleItemId { get; set; }
    public virtual StudentCourseEnrollment? StudentCourseEnrollment  { get; set; }
    public virtual CourseSemester? CourseSemester { get; set; }
    public virtual Semester? Semester { get; set; }
    public virtual GradeScaleItem? GradeScaleItem { get; set; }

    ///// <summary>
    ///// الساعات المحاولة
    ///// </summary>
    //public decimal? CreditsAttempted { get; set; }

    ///// <summary>
    ///// الساعات المكتسبة
    ///// </summary>
    //public decimal? CreditsEarned { get; set; }


    ///// <summary>
    ///// هل نهائي
    ///// </summary>
    //public bool IsFinal { get; set; } = false;

    ///// <summary>
    ///// ملاحظات
    ///// </summary>
    //public string? Comment { get; set; }

    ///// <summary>
    ///// نشر بواسطة
    ///// </summary>
    //public int? PostedBy { get; set; }

    ///// <summary>
    ///// تاريخ النشر
    ///// </summary>
    //public DateTime? PostedAt { get; set; }
}
