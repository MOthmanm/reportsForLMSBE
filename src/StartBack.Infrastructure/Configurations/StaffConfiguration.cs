using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Contracts.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StaffConfiguration : BaseConfiguration<Staff>
{
    public override void Configure(EntityTypeBuilder<Staff> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الموظفين والأساتذة");

        builder.Property(e => e.Id).HasComment("معرّف الموظف");
        builder.Property(e => e.StaffCode).HasComment("رمز الموظف");
        builder.Property(e => e.Title).HasComment("اللقب");
        builder.Property(e => e.FirstName).HasComment("الاسم الأول");
        builder.Property(e => e.MiddleName).HasComment("الاسم الأوسط");
        builder.Property(e => e.LastName).HasComment("اسم العائلة");
        builder.Property(e => e.NameSuffix).HasComment("اللاحقة");
        builder.Property(e => e.Gender)
            .HasConversion<int>()
            .HasComment("الجنس");
        builder.Property(e => e.Birthdate).HasComment("تاريخ الميلاد");
        builder.Property(e => e.NationalityId).HasComment("معرّف الجنسية");
        builder.Property(e => e.NationalId).HasComment("رقم الهوية");
        builder.Property(e => e.Email).HasComment("البريد الإلكتروني");
        builder.Property(e => e.Phone).HasComment("رقم الهاتف");
        builder.Property(e => e.Mobile).HasComment("رقم الجوال");
        builder.Property(e => e.Address).HasComment("العنوان");
        builder.Property(e => e.StaffCategoryId).HasComment("معرّف فئة الموظف");
        builder.Property(e => e.HireDate).HasComment("تاريخ التعيين");
        builder.Property(e => e.TerminationDate).HasComment("تاريخ إنهاء الخدمة");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
        builder.Property(e => e.PhotoPath).HasComment("مسار الصورة");

        builder.HasOne(d => d.Nationality)
               .WithMany()
               .HasForeignKey(d => d.NationalityId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.StaffCategory)
               .WithMany()
               .HasForeignKey(d => d.StaffCategoryId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}

