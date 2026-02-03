using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class TranscriptConfiguration : BaseConfiguration<Transcript>
{
    public override void Configure(EntityTypeBuilder<Transcript> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول السجل الأكاديمي (الشهادة الدراسية)");

        builder.Property(e => e.Id).HasComment("معرّف السجل");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الطالب بالجامعة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.UniversityName).HasComment("اسم الجامعة");
        builder.Property(e => e.AcademicYearId).HasComment("معرّف السنة الدراسية");
        builder.Property(e => e.AcademicYearTitle).HasComment("عنوان السنة الدراسية");
        builder.Property(e => e.AcademicLevel).HasComment("المستوى الأكاديمي");
        builder.Property(e => e.CourseCode).HasComment("رمز المقرر");
        builder.Property(e => e.CourseTitle).HasComment("اسم المقرر");
        builder.Property(e => e.LetterGrade).HasComment("التقدير");
        builder.Property(e => e.GradePercent).HasComment("النسبة المئوية");
        builder.Property(e => e.GpaValue).HasComment("قيمة المعدل");
        builder.Property(e => e.CreditsAttempted).HasComment("الساعات المحاولة");
        builder.Property(e => e.CreditsEarned).HasComment("الساعات المكتسبة");
        builder.Property(e => e.IncludeInGpa).HasComment("يحسب في المعدل");
        builder.Property(e => e.IsTransfer).HasComment("منقول");
        builder.Property(e => e.Notes).HasComment("ملاحظات");

        builder.HasOne(d => d.PersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
