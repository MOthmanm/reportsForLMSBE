using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

public class CourseDegreeDevisionCourse : BaseTable
{
    public int CourseId { get; set; }
    public int LookupCourseDegreeDevisionId { get; set; }
    public decimal? Percentage { get; set; }
    public virtual Course? Course  { get; set; }
    public virtual LookupCourseDegreeDevision? LookupCourseDegreeDevision { get; set; }


}

