using Entities.Models.BaseTables;
using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول المقررات الدراسية
/// </summary>
public class Course : BaseTable, ITenantEntity
{

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    [MaxLength(50)]
    public string Code { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// الساعات المعتمدة
    /// </summary>
    public decimal? CreditHours { get; set; }

    /// <summary>
    /// مادة رسوب للعام - الرسوب فيها يعني رسوب في السنة
    /// </summary>
    public bool? IsYearFail { get; set; } = false;

    /// <summary>
    /// مطلوب للتخرج - مادة إجبارية للتخرج
    /// </summary>
    public bool? IsGraduationRequired { get; set; } = false;

    /// <summary>
    /// يحسب في المعدل - يتم تضمينه في حساب تقدير الطالب
    /// </summary>
    public bool IncludeInGpa { get; set; } = true;

    /// <summary>
    /// النهاية العظمى للدرجة
    /// </summary>
    public decimal? MaximumDegree { get; set; }

    public bool IsActive { get; set; } = true;

    public int UniversityId { get; set; }
    public int CourseCategoryId { get; set; }
    public int? GradeScaleId { get; set; }
    public int? CourseTypeId { get; set; }


    public virtual University? University { get; set; }
    public virtual CourseCategory? CourseCategory { get; set; }
    public virtual GradeScale? GradeScale { get; set; }
    public virtual CourseType? CourseType { get; set; }
    public virtual ICollection<AcademicLevelCourse> AcademicLevelCourses { get; set; } = new List<AcademicLevelCourse>();
    public virtual ICollection<CourseSemester> CourseSemesters  { get; set; } = new List<CourseSemester>();
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    public virtual ICollection<CourseDegreeDevisionCourse> CourseDegreeDevisionCourses  { get; set; } = new List<CourseDegreeDevisionCourse>();



}
