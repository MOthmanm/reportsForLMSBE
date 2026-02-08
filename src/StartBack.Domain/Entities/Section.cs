using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الفصول والشعب الدراسية
/// </summary>
public class Section : BaseTable, ITenantEntity
{

    public string Name { get; set; } = null!;
    public int? Capacity { get; set; }
    public int SortOrder { get; set; }

    public int UniversityId { get; set; }
    public int AcademicYearId { get; set; }
    public int AcademicLevelId { get; set; }
    public int AcademicLevelIterationId { get; set; }
    public virtual University? University { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }
    public virtual AcademicLevel? AcademicLevel { get; set; }
    public virtual AcademicLevelIteration? AcademicLevelIteration { get; set; }
    public virtual ICollection<CourseSemesterSection> CourseSemesterSections { get; set; } = new List<CourseSemesterSection>();
    public virtual ICollection<PersonUniversitySection> PersonUniversitySections { get; set; } = new List<PersonUniversitySection>();


}
