using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AssignmentGradeConfiguration : BaseConfiguration<AssignmentGrade>
{
    public override void Configure(EntityTypeBuilder<AssignmentGrade> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول درجات التكليفات (دفتر الدرجات)");

        builder.Property(e => e.Id).HasComment("معرّف السجل");
        builder.Property(e => e.AssignmentId).HasComment("معرّف التكليف");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الطالب بالجامعة");
        builder.Property(e => e.PointsEarned).HasComment("النقاط المكتسبة");
        builder.Property(e => e.LetterGrade).HasComment("التقدير");
        builder.Property(e => e.IsExcused).HasComment("معذور");
        builder.Property(e => e.IsIncomplete).HasComment("غير مكتمل");
        builder.Property(e => e.IsLate).HasComment("متأخر");
        builder.Property(e => e.Comment).HasComment("تعليق");
        builder.Property(e => e.GradedBy).HasComment("تم التقييم بواسطة");
        builder.Property(e => e.GradedAt).HasComment("تم التقييم في");

        builder.HasOne(d => d.Assignment)
               .WithMany()
               .HasForeignKey(d => d.AssignmentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.PersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.AssignmentId, e.PersonUniversityId }).IsUnique();
    }
}
