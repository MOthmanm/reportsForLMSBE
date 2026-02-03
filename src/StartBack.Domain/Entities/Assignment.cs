using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول التكليفات والواجبات الدراسية
/// </summary>
public class Assignment : BaseTable
{
    /// <summary>
    /// معرّف حصة المقرر
    /// </summary>
    public int CourseSectionId { get; set; }
    public virtual CourseSemester? CourseSection { get; set; }

    /// <summary>
    /// معرّف نوع التكليف
    /// </summary>
    public int? AssignmentTypeId { get; set; }
    public virtual AssignmentType? AssignmentType { get; set; }

    /// <summary>
    /// معرّف الفصل الدراسي
    /// </summary>
    public int? SemesterId { get; set; }
    public virtual Semester? Semester { get; set; }

    /// <summary>
    /// معرّف الربع
    /// </summary>
    public int? QuarterId { get; set; }
    public virtual Quarter? Quarter { get; set; }

    /// <summary>
    /// عنوان التكليف
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// وصف التكليف
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاريخ التكليف
    /// </summary>
    public DateOnly? AssignedDate { get; set; }

    /// <summary>
    /// تاريخ الاستحقاق
    /// </summary>
    public DateOnly? DueDate { get; set; }

    /// <summary>
    /// النقاط القصوى
    /// </summary>
    public decimal MaxPoints { get; set; }

    /// <summary>
    /// هل هو درجات إضافية
    /// </summary>
    public bool IsExtraCredit { get; set; } = false;

    /// <summary>
    /// هل يتم تقييمه
    /// </summary>
    public bool IsGraded { get; set; } = true;

    /// <summary>
    /// تم الإنشاء بواسطة
    /// </summary>
    public int? CreatedBy { get; set; }
}
