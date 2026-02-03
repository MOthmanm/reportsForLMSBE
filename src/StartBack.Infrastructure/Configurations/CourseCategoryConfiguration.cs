using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseCategoryConfiguration : BaseConfiguration<CourseCategory>
{
    public override void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المقررات الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف المقرر");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Code).HasComment("رمز المقرر");
        builder.Property(e => e.Title).HasComment("اسم المقرر");
        //builder.Property(e => e.Credits).HasComment("الساعات المعتمدة");
        //builder.Property(e => e.CreditHours).HasComment("ساعات التدريس");
        //builder.Property(e => e.MaxScore).HasComment("النهاية العظمى للدرجات");
        //builder.Property(e => e.PassingScore).HasComment("درجة النجاح");
        //builder.Property(e => e.GradeRelation).HasComment("العلاقة بالمجموع الكلي (PART_OF_FINAL=جزء من النهائي، SEPARATE=منفصل، BONUS=إضافي، NOT_COUNTED=لا يحسب)");
        //builder.Property(e => e.IsYearFail).HasComment("مادة رسوب للعام - الرسوب فيها يعني رسوب في السنة");
        //builder.Property(e => e.IsGraduationRequired).HasComment("مطلوب للتخرج - مادة إجبارية للتخرج");
        //builder.Property(e => e.IsWeighted).HasComment("مقرر موزون");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

        builder.HasOne(d => d.University)
               .WithMany(d => d.CourseCategories)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.UniversityId, e.Code }).IsUnique();
    }
}

