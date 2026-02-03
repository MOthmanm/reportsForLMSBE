using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StudentGpaConfiguration : BaseConfiguration<StudentGpa>
{
    public override void Configure(EntityTypeBuilder<StudentGpa> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المعدل التراكمي المحسوب للطلاب");

        builder.Property(e => e.Id).HasComment("معرّف السجل");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الطالب بالجامعة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.AcademicYearId).HasComment("معرّف السنة الدراسية");
        builder.Property(e => e.SemesterId).HasComment("معرّف الفصل الدراسي");
        builder.Property(e => e.Gpa).HasComment("المعدل الفصلي");
        builder.Property(e => e.WeightedGpa).HasComment("المعدل الموزون");
        builder.Property(e => e.CumulativeGpa).HasComment("المعدل التراكمي");
        builder.Property(e => e.ClassRank).HasComment("ترتيب الدفعة");
        builder.Property(e => e.ClassSize).HasComment("عدد الدفعة");
        builder.Property(e => e.CreditsEarned).HasComment("الساعات المكتسبة");
        builder.Property(e => e.CalculatedAt).HasComment("تاريخ الحساب");

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

        builder.HasOne(d => d.Semester)
               .WithMany()
               .HasForeignKey(d => d.SemesterId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => new { e.PersonUniversityId, e.AcademicYearId, e.SemesterId }).IsUnique();
    }
}
