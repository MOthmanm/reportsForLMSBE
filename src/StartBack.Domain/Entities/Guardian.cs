using Entities.Models.BaseTables;
using Contracts.enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Tables;

/// <summary>
/// جدول أولياء الأمور
/// </summary>
public class Guardian : BaseTable
{
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
    /// الجنس
    /// </summary>
    public Gender? Gender { get; set; }

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
    /// المهنة
    /// </summary>
    [MaxLength(100)]
    public string? Occupation { get; set; }

    /// <summary>
    /// مكان العمل
    /// </summary>
    [MaxLength(200)]
    public string? Workplace { get; set; }

    /// <summary>
    /// هل نشط
    /// </summary>
    public bool IsActive { get; set; } = true;
}
