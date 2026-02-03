using Entities.Models.BaseTables;
using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول حوادث السلوك والانضباط
/// </summary>
public class DisciplineIncident : BaseTable
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
    /// رمز الحادثة
    /// </summary>
    [MaxLength(30)]
    public string? IncidentCode { get; set; }

    /// <summary>
    /// تاريخ الحادثة
    /// </summary>
    public DateOnly IncidentDate { get; set; }

    /// <summary>
    /// وقت الحادثة
    /// </summary>
    public TimeOnly? IncidentTime { get; set; }

    /// <summary>
    /// معرّف نوع الحادثة
    /// </summary>
    public int? IncidentTypeId { get; set; }
    public virtual LookupIncidentType? IncidentType { get; set; }

    /// <summary>
    /// المكان
    /// </summary>
    [MaxLength(200)]
    public string? Location { get; set; }

    /// <summary>
    /// وصف الحادثة
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// المبلغ (علاقة الموظف بالجامعة)
    /// </summary>
    public int? ReporterPersonUniversityId { get; set; }
    public virtual PersonUniversity? ReporterPersonUniversity { get; set; }

    /// <summary>
    /// المسند إليه
    /// </summary>
    public int? AssignedToId { get; set; }

    /// <summary>
    /// الحالة
    /// </summary>
    public IncidentStatus Status { get; set; } = IncidentStatus.Open;

    /// <summary>
    /// القرار
    /// </summary>
    public string? Resolution { get; set; }

    /// <summary>
    /// تاريخ الحل
    /// </summary>
    public DateTime? ResolvedAt { get; set; }
}
