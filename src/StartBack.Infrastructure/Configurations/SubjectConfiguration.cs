using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class SubjectConfiguration : BaseConfiguration<Subject>
{
    public override void Configure(EntityTypeBuilder<Subject> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المواد الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف المادة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.AcademicYearId).HasComment("معرّف السنة الدراسية");
        builder.Property(e => e.Code).HasComment("رمز المادة");
        builder.Property(e => e.Title).HasComment("اسم المادة");
        builder.Property(e => e.ShortName).HasComment("الاسم المختصر");
        builder.Property(e => e.SubjectTypeId).HasComment("معرّف نوع المادة");
        builder.Property(e => e.Description).HasComment("وصف المادة");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشطة");

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.AcademicYear)
               .WithMany()
               .HasForeignKey(d => d.AcademicYearId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.SubjectType)
               .WithMany()
               .HasForeignKey(d => d.SubjectTypeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => new { e.UniversityId, e.AcademicYearId, e.Code }).IsUnique();
    }
}
