using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;
using Contracts.enums;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الفترات الزمنية اليومية
/// </summary>
public class Period : BaseTable, ITenantEntity
{

 
    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// وقت البداية
    /// </summary>
    public TimeOnly StartTime { get; set; }

    /// <summary>
    /// وقت النهاية
    /// </summary>
    public TimeOnly EndTime { get; set; }

    /// <summary>
    /// المدة بالدقائق
    /// </summary>
    public int LengthMinutes { get; set; }

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// نوع الفترة
    /// </summary>
    public PeriodType PeriodType { get; set; }

    /// <summary>
    /// الحضور مطلوب
    /// </summary>
    public bool IsAttendanceRequired { get; set; } = true;

    /// <summary>
    /// هل نشطة
    /// </summary>
    public bool IsActive { get; set; } = true;

    public int UniversityId { get; set; }

    public virtual University? University { get; set; }
    public virtual ICollection<CourseSectionMeeting> CourseSectionMeetings { get; set; } = new List<CourseSectionMeeting>();


}
