using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

/// <summary>
/// جدول حالة إتمام تسجيل الحضور
/// </summary>
public class AttendanceCompleted : BaseTable
{
    /// <summary>
    /// معرّف موعد المحاضرة
    /// </summary>
    public int CourseSectionMeetingId { get; set; }
    public virtual CourseSectionMeeting? CourseSectionMeeting { get; set; }

    /// <summary>
    /// معرّف علاقة الموظف بالجامعة
    /// </summary>
    public int PersonUniversityId { get; set; }
    public virtual PersonUniversity? PersonUniversity { get; set; }
}
