using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

public class PersonUniversitySection : BaseTable
{
    public int PersonUniversityId { get; set; }
    public int SectionId { get; set; }
    public int AcademicYearId { get; set; }
    public virtual PersonUniversity? PersonUniversity  { get; set; }
    public virtual Section? Section  { get; set; }
    public virtual AcademicYear? AcademicYear  { get; set; }

}


