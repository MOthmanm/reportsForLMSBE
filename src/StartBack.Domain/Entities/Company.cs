using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول السرايا العسكرية
/// </summary>
public class Company : BaseTable
{
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string NameAr { get; set; } = null!;

    [MaxLength(200)]
    public string? NameEn { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public int BattalionId { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    
    public virtual Battalion? Battalion { get; set; }
    public virtual ICollection<Platoon> Platoons { get; set; } = new List<Platoon>();
    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new List<StudentEnrollment>();

}
