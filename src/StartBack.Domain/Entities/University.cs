using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الجامعات والمؤسسات الأكاديمية
/// </summary>
public class University : BaseTable
{
    public string NameAr { get; set; } = null!;
    public string? NameEn { get; set; }
    public string? ShortName { get; set; }
    public string? Icon { get; set; }
    public int? ParentId { get; set; }
    public int? Level { get; set; }


    public virtual University? Parent { get; set; }
    public virtual ICollection<University> Childern { get; set; }
    public virtual ICollection<PersonUniversity> PersonUniversities { get; set; } = new List<PersonUniversity>();
    public virtual ICollection<AcademicYear> AcademicYears { get; set; } = new List<AcademicYear>();
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    public virtual ICollection<AcademicCalendar> AcademicCalendars { get; set; } = new List<AcademicCalendar>();
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();
    public virtual ICollection<Period> Periods { get; set; } = new List<Period>();
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
    public bool IsActive { get; set; } = true;
}
