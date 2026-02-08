using Entities.Models.BaseTables;
using Contracts.enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول العلاقة بين الأشخاص والجامعات (Many-to-Many)
/// </summary>
public class PersonUniversity : BaseTable, ITenantEntity
{
    public int PersonId { get; set; }
    public int UniversityId { get; set; }

    public PersonType PersonType { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    public virtual Person? Person { get; set; }
    public virtual University? University { get; set; }
    public virtual ICollection<PersonUniversityJob> PersonUniversityJobs { get; set; } = new List<PersonUniversityJob>();
    public virtual ICollection<PersonUniversitySection> PersonUniversitySections { get; set; } = new List<PersonUniversitySection>();
    public virtual ICollection<PersonUniversityQualification> PersonUniversityQualifications { get; set; } = new List<PersonUniversityQualification>();
    public virtual ICollection<StudentCourseEnrollment> StudentCourseEnrollments { get; set; } = new List<StudentCourseEnrollment>();
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    public virtual ICollection<StudentEnrollment> StudentEnrollments  { get; set; } = new List<StudentEnrollment>();

}

