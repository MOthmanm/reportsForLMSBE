using Entities.Models.BaseTables;
using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الإجراءات التأديبية
/// </summary>
public class DisciplineAction : BaseTable
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
    /// معرّف نوع الإجراء
    /// </summary>
    public int ActionTypeId { get; set; }
    public virtual LookupDisciplineActionType? ActionType { get; set; }

    /// <summary>
    /// تاريخ الإجراء
    /// </summary>
    public DateOnly ActionDate { get; set; }

    /// <summary>
    /// تاريخ البدء
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// تاريخ الانتهاء
    /// </summary>
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// المدة بالأيام
    /// </summary>
    public int? DurationDays { get; set; }

    /// <summary>
    /// وصف الإجراء
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// صدر بواسطة (علاقة الموظف بالجامعة)
    /// </summary>
    public int? IssuedByPersonUniversityId { get; set; }
    public virtual PersonUniversity? IssuerPersonUniversity { get; set; }

    /// <summary>
    /// تم إشعار ولي الأمر
    /// </summary>
    public bool ParentNotified { get; set; } = false;

    /// <summary>
    /// تاريخ الإشعار
    /// </summary>
    public DateOnly? NotificationDate { get; set; }

    /// <summary>
    /// الحالة
    /// </summary>
    public ActionStatus Status { get; set; } = ActionStatus.Pending;
}
