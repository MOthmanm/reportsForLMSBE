using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;


// بقول ان الترم الدراسى فيه شويه كورسات
public class CourseSemester : BaseTable
{


    public int CourseId { get; set; }
    public int SemesterId { get; set; }
    public int AcademicLevelIterationId { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual Course? Course { get; set; }
    public virtual Semester? Semester  { get; set; }
    public virtual AcademicLevelIteration? AcademicLevelIteration  { get; set; }
    public virtual ICollection<CourseSemesterSection> CourseSemesterSections  { get; set; } = new List<CourseSemesterSection>();
    public virtual ICollection<FinalGrade> FinalGrades   { get; set; } = new List<FinalGrade>();

}
