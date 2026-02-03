using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الحضور بالحصة
/// </summary>
public class AttendancePeriod : BaseTable
{
    /// <summary>
    /// معرّف المقرر
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// معرّف تسجيل الطالب في المقرر
    /// </summary>
    public int StudentCourseEnrollmentId { get; set; }
    public virtual StudentCourseEnrollment? StudentCourseEnrollment { get; set; }

    /// <summary>
    /// معرّف موعد المحاضرة
    /// </summary>
    public int CourseSectionMeetingId { get; set; }
    public virtual CourseSectionMeeting? CourseSectionMeeting { get; set; }

    /// <summary>
    /// معرّف كود الحضور
    /// </summary>
    public int? AttendanceCodeId { get; set; }
    public virtual LookupAttendanceCode? AttendanceCode { get; set; }

    /// <summary>
    /// السبب
    /// </summary>
    [MaxLength(200)]
    public string? Reason { get; set; }

    /// <summary>
    /// ملاحظة
    /// </summary>
    [MaxLength(255)]
    public string? Comment { get; set; }
}
