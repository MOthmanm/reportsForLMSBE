using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CoursePrerequisiteConfiguration : BaseConfiguration<CoursePrerequisite>
{
    public override void Configure(EntityTypeBuilder<CoursePrerequisite> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المتطلبات السابقة للمقررات");

        builder.Property(e => e.Id).HasComment("معرّف السجل"); // Default base comment if not specified in SQL, or specific if needed. SQL didn't specify ID comment for this, but I'll leave it as base.
        builder.Property(e => e.CourseId).HasComment("معرّف المقرر");
        builder.Property(e => e.PrerequisiteCourseId).HasComment("معرّف المقرر السابق المطلوب");
        builder.Property(e => e.IsMandatory).HasComment("هل المتطلب إجباري");
        builder.Property(e => e.MinGrade).HasComment("الحد الأدنى للتقدير المطلوب");
        //builder.Property(e => e.Notes).HasComment("ملاحظات"); // Not in SQL comments block but good to have if present.

        builder.HasOne(d => d.Course)
               .WithMany()
               .HasForeignKey(d => d.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.PrerequisiteCourse)
               .WithMany()
               .HasForeignKey(d => d.PrerequisiteCourseId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.CourseId, e.PrerequisiteCourseId }).IsUnique();
    }
}
