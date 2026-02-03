using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

public class PersonUniversityJob : BaseTable
{
    public int PersonUniversityId { get; set; }
    public int JobId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool? IsCurrent { get; set; }
    public PersonUniversity? PersonUniversity { get; set; }
    public Job? Job { get; set; }
}
