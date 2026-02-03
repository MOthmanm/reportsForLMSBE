using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

public class StudentEnrollment : BaseTable
{
    public int PersonUniversityId { get; set; }
    public int AcademicLevelId { get; set; }
    public int AcademicYearId { get; set; }
    public int? AcademicLevelIterationId { get; set; }
    public int? SectionId { get; set; }
    public bool? IsCurrent { get; set; }
    public PersonUniversity? PersonUniversity { get; set; }
    public AcademicLevel? AcademicLevel  { get; set; }
    public AcademicYear? AcademicYear { get; set; }
    public AcademicLevelIteration? AcademicLevelIteration { get; set; }
    public Section? Section { get; set; }

}
