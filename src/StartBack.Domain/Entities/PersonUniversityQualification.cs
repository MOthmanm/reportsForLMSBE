using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول مؤهلات الشخص في الجامعة
/// </summary>
public class PersonUniversityQualification : BaseTable
{
    /// <summary>
    /// معرّف العلاقة بين الشخص والجامعة
    /// </summary>
    public int PersonUniversityId { get; set; }

    /// <summary>
    /// معرّف الكلية
    /// </summary>
    public int CollegeId { get; set; }

    /// <summary>
    /// معرّف المؤهل العلمي
    /// </summary>
    public int QualificationId { get; set; }

    /// <summary>
    /// تاريخ الحصول على المؤهل
    /// </summary>
    public DateOnly? QualificationDate { get; set; }

    /// <summary>
    /// ملاحظات
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsCurrent { get; set; } = true;

    // Navigation Properties
    public virtual PersonUniversity? PersonUniversity { get; set; }
    public virtual LookupCollege? College { get; set; }
    public virtual LookupQualification? Qualification { get; set; }
}

