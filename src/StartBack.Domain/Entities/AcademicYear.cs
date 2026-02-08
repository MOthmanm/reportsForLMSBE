using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول السنوات الدراسية
/// </summary>
public class AcademicYear : BaseTable, ITenantEntity
{

    /// <summary>
    /// عنوان السنة الدراسية
    /// </summary>

    public string Title { get; set; } = null!;

    /// <summary>
    /// الاسم المختصر
    /// </summary>

    public string ShortName { get; set; } = null!;

    /// <summary>
    /// تاريخ البداية
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// تاريخ النهاية
    /// </summary>
    public DateOnly EndDate { get; set; }

    /// <summary>
    /// هل السنة الحالية
    /// </summary>
    public bool IsCurrent { get; set; }
    /// <summary>
    /// معرّف الجامعة
    /// </summary>
    public int UniversityId { get; set; }
    public virtual University? University { get; set; }
    public virtual ICollection<AcademicLevelIteration> AcademicLevelIterations { get; set; } = new List<AcademicLevelIteration>();
    public virtual ICollection<GradeScale> GradeScales   { get; set; } = new List<GradeScale>();
    public virtual ICollection<Semester> Semesters { get; set; } = new List<Semester>();
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    public virtual AcademicCalendar? AcademicCalendar { get; set; }
    public virtual ICollection<PersonUniversitySection> PersonUniversitySections { get; set; } = new List<PersonUniversitySection>();


}
