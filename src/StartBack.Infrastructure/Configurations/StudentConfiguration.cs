using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Contracts.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StudentConfiguration : BaseConfiguration<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول بيانات الطلاب");

        builder.Property(e => e.Id).HasComment("معرّف الطالب");
        builder.Property(e => e.StudentCode).HasComment("رمز الطالب");
        builder.Property(e => e.CurrentUniversityId).HasComment("معرّف الجامعة الحالية");
        builder.Property(e => e.FirstName).HasComment("الاسم الأول");
        builder.Property(e => e.MiddleName).HasComment("الاسم الأوسط");
        builder.Property(e => e.LastName).HasComment("اسم العائلة");
        builder.Property(e => e.NameSuffix).HasComment("اللاحقة");
        builder.Property(e => e.NameAr).HasComment("الاسم الكامل بالعربية");
        builder.Property(e => e.Gender)
            .HasConversion<int>()
            .HasComment("الجنس");
        builder.Property(e => e.Birthdate).HasComment("تاريخ الميلاد");
        builder.Property(e => e.NationalityId).HasComment("معرّف الجنسية");
        builder.Property(e => e.NationalId).HasComment("رقم الهوية");
        builder.Property(e => e.MilitaryNumber).HasComment("الرقم العسكري");
        builder.Property(e => e.HighSchoolGraduationDate).HasComment("تاريخ الحصول على شهادة الثانوية العامة");
        builder.Property(e => e.HighSchoolScore).HasComment("مجموع الثانوية العامة");
        builder.Property(e => e.HighSchoolPercentage).HasComment("النسبة المئوية في الثانوية العامة");
        builder.Property(e => e.BatchNumber).HasComment("رقم الدفعة");
        builder.Property(e => e.EthnicityId).HasComment("معرّف العرق");
        builder.Property(e => e.LanguageId).HasComment("معرّف اللغة");
        builder.Property(e => e.Email).HasComment("البريد الإلكتروني");
        builder.Property(e => e.Phone).HasComment("رقم الهاتف");
        builder.Property(e => e.Mobile).HasComment("رقم الجوال");
        builder.Property(e => e.Address).HasComment("العنوان");

        // Housing
        builder.Property(e => e.HousingBuilding).HasComment("المبنى");
        builder.Property(e => e.HousingFloor).HasComment("الطابق/العمارة");
        builder.Property(e => e.HousingRoom).HasComment("رقم الغرفة");
        builder.Property(e => e.HousingLocker).HasComment("رقم الدوالب");
        builder.Property(e => e.HousingWeapon).HasComment("السلاح (مشاة، مدرعات، الخ)");
        builder.Property(e => e.HousingCompany).HasComment("السرية العسكرية");
        builder.Property(e => e.HousingPlatoon).HasComment("الفصيلة العسكرية");
        builder.Property(e => e.HousingSquad).HasComment("الجماعة العسكرية");

        builder.Property(e => e.IsActive).HasComment("هل نشط");
        builder.Property(e => e.PhotoPath).HasComment("مسار الصورة");


        builder.HasOne(d => d.CurrentUniversity)
               .WithMany()
               .HasForeignKey(d => d.CurrentUniversityId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Nationality)
               .WithMany()
               .HasForeignKey(d => d.NationalityId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Ethnicity)
               .WithMany()
               .HasForeignKey(d => d.EthnicityId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Language)
               .WithMany()
               .HasForeignKey(d => d.LanguageId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}

