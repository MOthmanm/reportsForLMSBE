using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول التقويمات الأكاديمية
/// </summary>
public class AcademicCalendar : BaseTable, ITenantEntity
{
    public string Title { get; set; } = null!;
    public int UniversityId { get; set; }
    public int AcademicYearId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsDefault { get; set; }
    public string? RecurringDays { get; set; }

    public virtual University? University { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }
    public virtual ICollection<AcademicCalendarDetail> AcademicCalendarDetails { get; set; } = new List<AcademicCalendarDetail>();


}
