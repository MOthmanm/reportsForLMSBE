using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Contracts.enums;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class PersonConfiguration : BaseConfiguration<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الأشخاص (موظفين، طلاب، موظفين)");

        builder.Property(e => e.Id).HasComment("معرّف الشخص");

        builder.Property(e => e.NationalId)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("الرقم الوطني - فريد");
        
        // Make NationalId unique
        builder.HasIndex(e => e.NationalId)
            .IsUnique()
            .HasDatabaseName("ix_person_national_id_unique");

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("الاسم الأول");

        builder.Property(e => e.MiddleName)
            .HasMaxLength(100)
            .HasComment("الاسم الأوسط");

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("اسم العائلة");

        builder.Property(e => e.Gender)
            .HasConversion<int>()
            .HasComment("الجنس");

        builder.Property(e => e.Birthdate)
            .HasComment("تاريخ الميلاد");

        builder.Property(e => e.Email)
            .HasMaxLength(200)
            .HasComment("البريد الإلكتروني");

        builder.Property(e => e.Mobile)
            .HasMaxLength(50)
            .HasComment("رقم الجوال");

        builder.Property(e => e.Address)
            .HasMaxLength(500)
            .HasComment("العنوان");

        builder.Property(e => e.MilitaryRankId)
            .HasComment("معرّف الرتبة العسكرية");

        builder.Property(e => e.BatchId)
            .HasComment("معرّف الدفعة");

        builder.Property(e => e.DistrictId)
            .HasComment("معرّف الحي/المنطقة");

        builder.Property(e => e.GovernateId)
            .HasComment("معرّف المحافظة");

        builder.Property(e => e.NationalityId)
            .HasComment("معرّف الجنسية");

        builder.Property(e => e.ReligionId)
            .HasComment("معرّف الدين");

        builder.Property(e => e.BloodTypeId)
            .HasComment("معرّف فصيلة الدم");

        builder.Property(e => e.WeaponId)
            .HasComment("معرّف السلاح");

        builder.Property(e => e.IsMilitary)
            .HasDefaultValue(false)
            .HasComment("هل عسكري");

        builder.Property(e => e.MilitaryNumber)
            .HasMaxLength(50)
            .HasComment("الرقم العسكري");

        builder.Property(p => p.FullName)
            .HasMaxLength(300)
            .ValueGeneratedOnAddOrUpdate()
            .HasComputedColumnSql(
                @"
        (
            ""first_name"" ||
            ' ' ||
            COALESCE(""middle_name"" || ' ', '') ||
            ""last_name""
        )
        ",
                stored: true
            );

        // Relationships
        builder.HasOne(d => d.MilitaryRank)
               .WithMany()
               .HasForeignKey(d => d.MilitaryRankId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Batch)
               .WithMany()
               .HasForeignKey(d => d.BatchId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.District)
               .WithMany()
               .HasForeignKey(d => d.DistrictId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Governate)
               .WithMany()
               .HasForeignKey(d => d.GovernateId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Nationality)
               .WithMany()
               .HasForeignKey(d => d.NationalityId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Religion)
               .WithMany()
               .HasForeignKey(d => d.ReligionId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.BloodType)
               .WithMany()
               .HasForeignKey(d => d.BloodTypeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Weapon)
               .WithMany()
               .HasForeignKey(d => d.WeaponId)
               .OnDelete(DeleteBehavior.SetNull);

        // Many-to-Many relationship with University
        builder.HasMany(d => d.PersonUniversities)
               .WithOne(pu => pu.Person)
               .HasForeignKey(pu => pu.PersonId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

