using Entities.Models.BaseTables;
using Contracts.enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول الموظفين والأساتذة
/// </summary>
public class Staff : BaseTable
{
    /// <summary>
    /// رمز الموظف
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string StaffCode { get; set; } = null!;

    /// <summary>
    /// اللقب
    /// </summary>
    [MaxLength(10)]
    public string? Title { get; set; }

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

    /// <summary>
    /// معرّف فئة الموظف
    /// </summary>
    public int? StaffCategoryId { get; set; }
    public virtual LookupStaffCategory? StaffCategory { get; set; }

    /// <summary>
    /// تاريخ التعيين
    /// </summary>
    public DateOnly? HireDate { get; set; }

    /// <summary>
    /// تاريخ إنهاء الخدمة
    /// </summary>
    public DateOnly? TerminationDate { get; set; }

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

