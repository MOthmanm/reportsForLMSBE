using Entities.Models.BaseTables;
using Contracts.enums;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الأشخاص (موظفين، طلاب، موظفين)
/// </summary>
public class Person : BaseTable
{


    public string NationalId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public Gender? Gender { get; set; }
    public DateOnly? Birthdate { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Address { get; set; }

    public int? MilitaryRankId { get; set; }
    public int? BatchId { get; set; }
    public int? DistrictId { get; set; }
    public int? GovernateId { get; set; }
    public int? NationalityId { get; set; }
    public int? ReligionId { get; set; }
    public int? BloodTypeId { get; set; }
    public int? WeaponId { get; set; }

    /// <summary>
    /// هل عسكري
    /// </summary>
    public bool IsMilitary { get; set; } = false;

    /// <summary>
    /// الرقم العسكري
    /// </summary>
    public string? MilitaryNumber { get; set; }

    public virtual LookupMilitaryRank? MilitaryRank { get; set; }
    public virtual LookupBatch? Batch { get; set; }
    public virtual LookupDistrict? District { get; set; }
    public virtual LookupGovernate? Governate { get; set; }
    public virtual LookupNationality? Nationality { get; set; }
    public virtual LookupReligion? Religion { get; set; }
    public virtual BloodType? BloodType { get; set; }
    public virtual LookupWeapon? Weapon { get; set; }
    public virtual ICollection<PersonUniversity> PersonUniversities { get; set; } = new List<PersonUniversity>();


}
