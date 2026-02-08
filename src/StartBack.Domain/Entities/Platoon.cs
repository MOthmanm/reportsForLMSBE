using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الفصائل العسكرية
/// </summary>
public class Platoon : BaseTable
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
    public int CompanyId { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual Company? Company { get; set; }
    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new List<StudentEnrollment>();

}
