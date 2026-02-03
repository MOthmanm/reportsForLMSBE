using Entities.Models.BaseTables;
using Contracts.enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول بيانات الطلاب
/// </summary>
public class Student : BaseTable
{
    /// <summary>
    /// رمز الطالب
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string StudentCode { get; set; } = null!;

    /// <summary>
    /// معرّف الجامعة الحالية
    /// </summary>
    public int? CurrentUniversityId { get; set; }
    public virtual University? CurrentUniversity { get; set; }

    /// <summary>
    /// الاسم الأول
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// الاسم الأوسط
    /// </summary>
    [MaxLength(100)]
    public string? MiddleName { get; set; }

    /// <summary>
    /// اسم العائلة
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// اللاحقة
    /// </summary>
    [MaxLength(10)]
    public string? NameSuffix { get; set; }

    /// <summary>
    /// الاسم الكامل بالعربية
    /// </summary>
    [MaxLength(200)]
    public string? NameAr { get; set; }

    /// <summary>
    /// الجنس
    /// </summary>
    public Gender? Gender { get; set; }

    /// <summary>
    /// تاريخ الميلاد
    /// </summary>
    public DateOnly? Birthdate { get; set; }

    /// <summary>
    /// معرّف الجنسية
    /// </summary>
    public int? NationalityId { get; set; }
    public virtual LookupNationality? Nationality { get; set; }

    /// <summary>
    /// رقم الهوية
    /// </summary>
    [MaxLength(50)]
    public string? NationalId { get; set; }

    /// <summary>
    /// الرقم العسكري
    /// </summary>
    [MaxLength(50)]
    public string? MilitaryNumber { get; set; }

    /// <summary>
    /// تاريخ الحصول على شهادة الثانوية العامة
    /// </summary>
    public DateOnly? HighSchoolGraduationDate { get; set; }

    /// <summary>
    /// مجموع الثانوية العامة
    /// </summary>
    public decimal? HighSchoolScore { get; set; }

    /// <summary>
    /// النسبة المئوية في الثانوية العامة
    /// </summary>
    public decimal? HighSchoolPercentage { get; set; }

    /// <summary>
    /// رقم الدفعة
    /// </summary>
    [MaxLength(20)]
    public string? BatchNumber { get; set; }

    /// <summary>
    /// معرّف العرق
    /// </summary>
    public int? EthnicityId { get; set; }
    public virtual LookupEthnicity? Ethnicity { get; set; }

    /// <summary>
    /// معرّف اللغة
    /// </summary>
    public int? LanguageId { get; set; }
    public virtual LookupLanguage? Language { get; set; }

    /// <summary>
    /// البريد الإلكتروني
    /// </summary>
    [MaxLength(200)]
    public string? Email { get; set; }

    /// <summary>
    /// رقم الهاتف
    /// </summary>
    [MaxLength(50)]
    public string? Phone { get; set; }

    /// <summary>
    /// رقم الجوال
    /// </summary>
    [MaxLength(50)]
    public string? Mobile { get; set; }

    /// <summary>
    /// العنوان
    /// </summary>
    public string? Address { get; set; }

    // Housing Information

    /// <summary>
    /// المبنى
    /// </summary>
    [MaxLength(50)] public string? HousingBuilding { get; set; }

    /// <summary>
    /// الطابق/العمارة
    /// </summary>
    [MaxLength(20)] public string? HousingFloor { get; set; }

    /// <summary>
    /// رقم الغرفة
    /// </summary>
    [MaxLength(20)] public string? HousingRoom { get; set; }

    /// <summary>
    /// رقم الدوالب
    /// </summary>
    [MaxLength(20)] public string? HousingLocker { get; set; }

    /// <summary>
    /// السلاح (مشاة، مدرعات، الخ)
    /// </summary>
    [MaxLength(50)] public string? HousingWeapon { get; set; }

    /// <summary>
    /// السرية العسكرية
    /// </summary>
    [MaxLength(50)] public string? HousingCompany { get; set; }

    /// <summary>
    /// الفصيلة العسكرية
    /// </summary>
    [MaxLength(50)] public string? HousingPlatoon { get; set; }

    /// <summary>
    /// الجماعة العسكرية
    /// </summary>
    [MaxLength(50)] public string? HousingSquad { get; set; }

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// مسار الصورة
    /// </summary>
    [MaxLength(500)]
    public string? PhotoPath { get; set; }
}

