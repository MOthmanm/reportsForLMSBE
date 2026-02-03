using Contracts.enums;
using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

public class Job : BaseTable
{
    public string Name { get; set; } = null!;
    public int? UniversityId { get; set; }

    public virtual University? University { get; set; }
    public virtual ICollection<PersonUniversityJob> PersonUniversityJobs { get; set; } = new List<PersonUniversityJob>();

}
