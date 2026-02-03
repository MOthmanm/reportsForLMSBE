using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

/// <summary>
/// جدول علاقة الطلاب بأولياء الأمور
/// </summary>
public class StudentGuardian : BaseTable
{
    /// <summary>
    /// معرّف علاقة الطالب بالجامعة
    /// </summary>
    public int PersonUniversityId { get; set; }
    public virtual PersonUniversity? PersonUniversity { get; set; }

    /// <summary>
    /// معرّف ولي الأمر
    /// </summary>
    public int GuardianId { get; set; }
    public virtual Guardian? Guardian { get; set; }

    /// <summary>
    /// معرّف نوع العلاقة
    /// </summary>
    public int RelationshipTypeId { get; set; }
    public virtual LookupRelationshipType? RelationshipType { get; set; }

    /// <summary>
    /// هل ولي الأمر الأساسي
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// جهة اتصال للطوارئ
    /// </summary>
    public bool IsEmergencyContact { get; set; }

    /// <summary>
    /// يمكنه استلام الطالب
    /// </summary>
    public bool CanPickup { get; set; } = true;

    /// <summary>
    /// لديه حق الوصاية
    /// </summary>
    public bool HasCustody { get; set; } = true;

    /// <summary>
    /// يستلم المراسلات
    /// </summary>
    public bool ReceivesMailing { get; set; } = true;
}
