using Entities.Models.BaseTables;
using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول القاعات والغرف
/// </summary>
public class Room : BaseTable
{

    [Required]
    [MaxLength(30)]
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(100)]
    public string? Building { get; set; }

    [MaxLength(20)]
    public string? Floor { get; set; }
    public int? Capacity { get; set; }
    public bool IsActive { get; set; } = true;
    public int UniversityId { get; set; }
    public virtual University? University { get; set; }
    public virtual ICollection<CourseSectionMeeting> CourseSectionMeetings { get; set; } = new List<CourseSectionMeeting>();

}
