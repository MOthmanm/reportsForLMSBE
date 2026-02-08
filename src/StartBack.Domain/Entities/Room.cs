using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;


public class Room : BaseTable
{

    [Required]
    [MaxLength(30)]
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    public int? FloorId { get; set; }
    
    public int? Capacity { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual Floor? Floor { get; set; }
    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new List<StudentEnrollment>();


}
