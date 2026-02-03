using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول تسجيل الطلاب في حصص المقررات
/// </summary>
public class StudentCourseEnrollment : BaseTable
{
    public int CourseSemesterSectionId { get; set; }
    public int PersonUniversityId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

    public virtual CourseSemesterSection? CourseSemesterSection  { get; set; }
    public virtual PersonUniversity? PersonUniversity  { get; set; }
    public virtual ICollection<AttendancePeriod> AttendancePeriods { get; set; } = new List<AttendancePeriod>();
    public virtual ICollection<FinalGrade> FinalGrades { get; set; } = new List<FinalGrade>();



}
