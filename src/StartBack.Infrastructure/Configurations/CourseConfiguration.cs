using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseConfiguration : BaseConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المقررات الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف المقرر");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Code).HasComment("رمز المقرر");
        builder.Property(e => e.Title).HasComment("اسم المقرر");
        builder.Property(e => e.Description).HasComment("وصف المقرر");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
        builder.Property(e => e.IsYearFail).HasDefaultValue(false);
        builder.Property(e => e.IsGraduationRequired).HasDefaultValue(false);
        builder.Property(e => e.CreditHours).HasDefaultValue(0m);
        builder.Property(e => e.IncludeInGpa).HasDefaultValue(true).HasComment("يحسب في المعدل - يتم تضمينه في حساب تقدير الطالب");
        builder.Property(e => e.MaximumDegree).HasDefaultValue(0m).HasComment("النهاية العظمى للدرجة");

        builder.HasOne(d => d.University)
               .WithMany(d=>d.Courses)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.CourseCategory)
       .WithMany(d => d.Courses)
       .HasForeignKey(d => d.CourseCategoryId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.CourseType)
               .WithMany()
               .HasForeignKey(d => d.CourseTypeId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

        builder.HasOne(d => d.GradeScale)
               .WithMany()
               .HasForeignKey(d => d.GradeScaleId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

        builder.HasIndex(e => new { e.UniversityId, e.Code }).IsUnique();
    }
}

