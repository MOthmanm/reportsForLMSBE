using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول المستويات الأكاديمية (شجرة هرمية)
/// </summary>
public class AcademicLevel : BaseTable
{

    /// <summary>
    /// اسم المستوى
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// الاسم المختصر
    /// </summary>
    public string ShortName { get; set; } = null!;


    /// <summary>
    /// ترتيب العرض
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// معرّف المستوى التالي
    /// </summary>
    public int? PreviousLevelId { get; set; }
    public virtual AcademicLevel? PreviousLevel { get; set; }

    /// <summary>
    /// معرّف المستوى التالي
    /// </summary>
    public int? NextLevelId { get; set; }
    public virtual AcademicLevel? NextLevel { get; set; }

    /// <summary>
    /// معرّف المستوى الأب
    /// </summary>
    public int? ParentId { get; set; }
    public virtual AcademicLevel? Parent { get; set; }
    public virtual ICollection<AcademicLevel> Children { get; set; } = new List<AcademicLevel>();
    public virtual ICollection<AcademicLevelIteration> AcademicLevelIterations { get; set; } = new List<AcademicLevelIteration>();
    public virtual ICollection<Semester> Semesters { get; set; } = new List<Semester>();
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    public virtual ICollection<AcademicLevelCourse> AcademicLevelCourses { get; set; } = new List<AcademicLevelCourse>();
    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new List<StudentEnrollment>();

    /// <summary>
    /// معرّف الجامعة
    /// </summary>
    public int UniversityId { get; set; }
    public virtual University? University { get; set; }
}
