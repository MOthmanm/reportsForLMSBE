using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول تعيينات الموظفين في الجامعات
/// </summary>
public class StaffUniversityAssignment : BaseTable, ITenantEntity
{
    /// <summary>
    /// معرّف علاقة الموظف بالجامعة
    /// </summary>
    public int PersonUniversityId { get; set; }
    public virtual PersonUniversity? PersonUniversity { get; set; }

    /// <summary>
    /// معرّف الجامعة
    /// </summary>
    public int UniversityId { get; set; }
    public virtual University? University { get; set; }

    /// <summary>
    /// معرّف السنة الدراسية
    /// </summary>
    public int AcademicYearId { get; set; }
    public virtual AcademicYear? AcademicYear { get; set; }

    /// <summary>
    /// المسمى الوظيفي
    /// </summary>
    [MaxLength(100)]
    public string? JobTitle { get; set; }

    /// <summary>
    /// القسم
    /// </summary>
    [MaxLength(100)]
    public string? Department { get; set; }

    /// <summary>
    /// تاريخ البدء
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// تاريخ الانتهاء
    /// </summary>
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// هل التعيين الأساسي
    /// </summary>
    public bool IsPrimary { get; set; } = true;

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsActive { get; set; } = true;
}
