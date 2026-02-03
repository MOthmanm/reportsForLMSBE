using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StaffUniversityAssignmentConfiguration : BaseConfiguration<StaffUniversityAssignment>
{
    public override void Configure(EntityTypeBuilder<StaffUniversityAssignment> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول تعيينات الموظفين في الجامعات");

        builder.Property(e => e.Id).HasComment("معرّف التعيين");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الموظف بالجامعة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.AcademicYearId).HasComment("معرّف السنة الدراسية");
        builder.Property(e => e.JobTitle).HasComment("المسمى الوظيفي");
        builder.Property(e => e.Department).HasComment("القسم");
        builder.Property(e => e.StartDate).HasComment("تاريخ البدء");
        builder.Property(e => e.EndDate).HasComment("تاريخ الانتهاء");
        builder.Property(e => e.IsPrimary).HasComment("هل التعيين الأساسي");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

        builder.HasOne(d => d.PersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.AcademicYear)
               .WithMany()
               .HasForeignKey(d => d.AcademicYearId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.PersonUniversityId, e.UniversityId, e.AcademicYearId }).IsUnique();
    }
}
