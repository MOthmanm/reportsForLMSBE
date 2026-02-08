using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class PersonUniversityQualificationConfiguration : BaseConfiguration<PersonUniversityQualification>
{
    public override void Configure(EntityTypeBuilder<PersonUniversityQualification> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول مؤهلات الشخص في الجامعة");

        builder.Property(e => e.Id).HasComment("معرّف السجل");

        builder.Property(e => e.PersonUniversityId)
            .IsRequired()
            .HasComment("معرّف العلاقة بين الشخص والجامعة");

        builder.Property(e => e.CollegeId)
            .IsRequired()
            .HasComment("معرّف الكلية");

        builder.Property(e => e.QualificationId)
            .IsRequired()
            .HasComment("معرّف المؤهل العلمي");

        builder.Property(e => e.QualificationDate)
            .HasComment("تاريخ الحصول على المؤهل");

        builder.Property(e => e.Notes)
            .HasMaxLength(500)
            .HasComment("ملاحظات");

        builder.Property(e => e.IsCurrent)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل نشط");

        // Relationships
        builder.HasOne(d => d.PersonUniversity)
               .WithMany(pu => pu.PersonUniversityQualifications)
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.College)
               .WithMany()
               .HasForeignKey(d => d.CollegeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Qualification)
               .WithMany()
               .HasForeignKey(d => d.QualificationId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.PersonUniversityId, e.CollegeId, e.QualificationId });
    }
}

