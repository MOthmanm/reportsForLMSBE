using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول رموز التقديرات
/// </summary>
public class GradeScaleItem : BaseTable
{
    public string Title { get; set; } = null!;
    public decimal MinPercent { get; set; }
    public decimal MaxPercent { get; set; }
    public int GradeScaleId { get; set; }
    public virtual GradeScale? GradeScale { get; set; }
    public virtual ICollection<FinalGrade> FinalGrades { get; set; } = new List<FinalGrade>();


}
