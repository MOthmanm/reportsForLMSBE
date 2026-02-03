using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الفصول الدراسية
/// </summary>
public class Semester : BaseTable
{
    public string Title { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int SortOrder { get; set; }
    public int AcademicYearId { get; set; }
    public int AcademicLevelId { get; set; }
    public int AcademicLevelIterationId { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }
    public virtual AcademicLevelIteration? AcademicLevelIteration { get; set; }
    public virtual AcademicLevel? AcademicLevel { get; set; }
    public virtual ICollection<CourseSemester> CourseSemesters { get; set; } = new List<CourseSemester>();
    public virtual ICollection<FinalGrade> FinalGrades { get; set; } = new List<FinalGrade>();


}
