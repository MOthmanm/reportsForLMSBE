using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول أنواع المقررات
/// </summary>
public class CourseType : BaseTable
{
    /// <summary>
    /// الاسم
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// عرض في التقويم
    /// </summary>
    public bool ShowInCalendar { get; set; } = true;
}

