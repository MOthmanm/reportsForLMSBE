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

    public int? BuildingId { get; set; }
    public int? FloorId { get; set; }
    public int? RoomId { get; set; }
    public int? BattalionId { get; set; }
    public int? CompanyId { get; set; }
    public int? PlatoonId { get; set; }
    public int? CupboardNumber { get; set; }
    public int? BedNumber { get; set; }



    public PersonUniversity? PersonUniversity { get; set; }
    public AcademicLevel? AcademicLevel  { get; set; }
    public AcademicYear? AcademicYear { get; set; }
    public AcademicLevelIteration? AcademicLevelIteration { get; set; }
    public Section? Section { get; set; }

    // «· ”ﬂÌ‰ «·«œ«—Ï

    public Building? Building { get; set; }
    public Floor? Floor { get; set; }
    public Room? Room { get; set; }

    //«· ”ﬂÌ‰ «·⁄”ﬂ—Ï

    public Battalion? Battalion { get; set; }
    public Company? Company { get; set; }
    public Platoon? Platoon { get; set; }

}
