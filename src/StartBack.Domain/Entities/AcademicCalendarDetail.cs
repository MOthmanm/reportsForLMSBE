using Contracts.enums;
using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول أيام التقويم الأكاديمي
/// </summary>
public class AcademicCalendarDetail : BaseTable
{
    public string? Notes { get; set; }
    public DateOnly AcademicDate { get; set; }
    public HolidayType HolidayType { get; set; }
    public int AcademicCalendarId { get; set; }
    public virtual AcademicCalendar? AcademicCalendar { get; set; }

}
