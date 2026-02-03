using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول المواد الدراسية
/// </summary>
public class Subject : BaseTable
{
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
    /// رمز المادة
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string Code { get; set; } = null!;

    /// <summary>
    /// اسم المادة
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// الاسم المختصر
    /// </summary>
    [MaxLength(50)]
    public string? ShortName { get; set; }

    /// <summary>
    /// معرّف نوع المادة
    /// </summary>
    public int? SubjectTypeId { get; set; }
    public virtual LookupSubjectType? SubjectType { get; set; }

    /// <summary>
    /// وصف المادة
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// هل نشطة
    /// </summary>
    public bool IsActive { get; set; } = true;
}
