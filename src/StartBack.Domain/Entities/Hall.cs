using Entities.Models.BaseTables;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

public class Hall : BaseTable
{

    [Required]
    [MaxLength(30)]
    public string Code { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;
    public int UniversityId { get; set; }
    public int? Capacity { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual University? University  { get; set; }
    public virtual ICollection<CourseSectionMeeting> CourseSectionMeetings { get; set; } = new List<CourseSectionMeeting>();

}