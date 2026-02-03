using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

public class CourseInstructor : BaseTable
{
    public int PersonUniversityId { get; set; }
    public int CourseId { get; set; }
    public PersonUniversity? PersonUniversity { get; set; }
    public Course? Course  { get; set; }
}
