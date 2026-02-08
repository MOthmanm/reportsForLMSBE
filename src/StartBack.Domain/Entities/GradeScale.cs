using Contracts.enums;
using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول مقاييس الدرجات
/// </summary>
public class GradeScale : BaseTable, ITenantEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public GradingType Type { get; set; }
    public bool IsDefault { get; set; }
    public int UniversityId { get; set; }
    public int AcademicYearId { get; set; }
    public virtual University? University { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }
    public virtual ICollection<GradeScaleItem> GradeScaleItems { get; set; } = new List<GradeScaleItem>();
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

}
