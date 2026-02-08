using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الكتائب العسكرية
/// </summary>
public class Battalion : BaseTable, ITenantEntity
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

    public bool IsActive { get; set; } = true;
    
    public int UniversityId { get; set; }
    
    public virtual University? University { get; set; }
    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new List<StudentEnrollment>();

}
