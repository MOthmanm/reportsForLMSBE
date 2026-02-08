using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول مواعيد انعقاد المحاضرات الفعلية
/// </summary>
public class CourseSectionMeeting : BaseTable
{
    public int CourseSemesterSectionId { get; set; }
    public int PeriodId { get; set; }
    public int HallId { get; set; }
    public int? CourseInstructorId { get; set; }
    public DateOnly MeetingDate { get; set; }
    public bool IsCancelled { get; set; } = false;

    [MaxLength(200)]
    public string? CancelReason { get; set; }
    public virtual CourseSemesterSection? CourseSemesterSection { get; set; }
    public virtual Period? Period { get; set; }
    public virtual Hall? Hall { get; set; }
    public virtual CourseInstructor? CourseInstructor { get; set; }
}
