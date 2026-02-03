using System.ComponentModel.DataAnnotations;
using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

public class AcademicLevelIteration : BaseTable
{


    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int SortOrder { get; set; }
    public int AcademicLevelId { get; set; }
    public int AcademicYearId { get; set; }

    [MaxLength(80)]
    public string Name { get; set; } = null!;

    public virtual AcademicLevel? AcademicLevel { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }
    public virtual ICollection<Semester> Semesters { get; set; } = new List<Semester>();
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    public virtual ICollection<CourseSemester> CourseSemesters { get; set; } = new List<CourseSemester>();

}
