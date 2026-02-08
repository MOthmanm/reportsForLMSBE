using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class GradeScaleConfiguration : BaseConfiguration<GradeScale>
{
    public override void Configure(EntityTypeBuilder<GradeScale> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول مقاييس الدرجات");

        builder.Property(e => e.Id).HasComment("معرّف المقياس");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Title).HasComment("اسم المقياس");
        builder.Property(e => e.Description).HasComment("وصف المقياس");
        builder.Property(e => e.IsDefault).HasComment("هل المقياس الافتراضي");
        builder.Property(e => e.AcademicYearId).HasComment("معرّف السنة الدراسية");
        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(d => d.AcademicYear)
       .WithMany(d=>d.GradeScales)
       .HasForeignKey(d => d.AcademicYearId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Courses)
               .WithOne(c => c.GradeScale)
               .HasForeignKey(c => c.GradeScaleId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
