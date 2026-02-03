using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class FinalGradeConfiguration : BaseConfiguration<FinalGrade>
{
    public override void Configure(EntityTypeBuilder<FinalGrade> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الدرجات النهائية للمقررات");

        builder.Property(e => e.Id).HasComment("معرّف السجل");
        builder.Property(e => e.CourseSemesterId).HasComment("معرّف حصة المقرر");
        builder.Property(e => e.SemesterId).HasComment("معرّف الفصل الدراسي");
        builder.Property(e => e.GradePercent).HasComment("النسبة المئوية");
        builder.Property(e => e.LetterGrade).HasComment("التقدير");
        builder.Property(e => e.GpaValue).HasComment("قيمة المعدل");

        builder.HasOne(d => d.CourseSemester)
               .WithMany(d => d.FinalGrades)
               .HasForeignKey(d => d.CourseSemesterId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.StudentCourseEnrollment)
       .WithMany(d => d.FinalGrades)
       .HasForeignKey(d => d.StudentCourseEnrollmentId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.GradeScaleItem)
       .WithMany(d => d.FinalGrades)
       .HasForeignKey(d => d.GradeScaleItemId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Semester)
       .WithMany(d => d.FinalGrades)
       .HasForeignKey(d => d.SemesterId)
       .OnDelete(DeleteBehavior.Restrict);



    }
}
