using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

// Ïå ÈíÍØ ÇáÓíßÔä Úáì ÇáßæÑÓ ÇáãæÌæÏ İì ÇáÊÑã ÇáÏÑÇÓì æãäåÇ ÈÃÚãá Êßáíİ ááØáÈå ÚÔÇä ÇŞÏÑ ÇÚãáå ÈÔßá íÏæí ŞÏÇã İ ÇáÌÏæá Çááì ÊÍÊå 
public class CourseSemesterSection : BaseTable
{
    public int CourseSemesterId { get; set; }
    public int SectionId { get; set; }
    public virtual CourseSemester? CourseSemester  { get; set; }
    public virtual Section? Section  { get; set; }
    public virtual ICollection<StudentCourseEnrollment> StudentCourseEnrollments { get; set; } = new List<StudentCourseEnrollment>();
    public virtual ICollection<CourseSectionMeeting> CourseSectionMeetings { get; set; } = new List<CourseSectionMeeting>();

}



