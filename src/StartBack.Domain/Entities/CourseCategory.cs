using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

public class CourseCategory : BaseTable, ITenantEntity
{


    [MaxLength(30)]
    public string Code { get; set; } = null!;
    [MaxLength(200)]
    public string Title { get; set; } = null!;
    public int UniversityId { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual University? University { get; set; }
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

}
