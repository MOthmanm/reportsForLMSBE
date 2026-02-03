using Entities.Models.BaseTables;
using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الطلاب المشاركين في حوادث السلوك
/// </summary>
public class DisciplineIncidentStudent : BaseTable
{
    /// <summary>
    /// معرّف الحادثة
    /// </summary>
    public int IncidentId { get; set; }
    public virtual DisciplineIncident? Incident { get; set; }

    /// <summary>
    /// معرّف علاقة الطالب بالجامعة
    /// </summary>
    public int PersonUniversityId { get; set; }
    public virtual PersonUniversity? PersonUniversity { get; set; }

    /// <summary>
    /// دور الطالب
    /// </summary>
    public IncidentRole Role { get; set; } = IncidentRole.Offender;

    /// <summary>
    /// ملاحظات
    /// </summary>
    public string? Notes { get; set; }
}
