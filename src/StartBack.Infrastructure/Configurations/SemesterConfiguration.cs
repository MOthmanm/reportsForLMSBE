using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class SemesterConfiguration : BaseConfiguration<Semester>
{
    public override void Configure(EntityTypeBuilder<Semester> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الفصول الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف الفصل الدراسي");
        builder.Property(e => e.Title).HasMaxLength(100).HasComment("عنوان الفصل");
        builder.Property(e => e.StartDate).HasComment("تاريخ البداية");
        builder.Property(e => e.EndDate).HasComment("تاريخ النهاية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");

        builder.HasOne(d => d.AcademicLevel)
               .WithMany(d=>d.Semesters)
               .HasForeignKey(d => d.AcademicLevelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicYear)
       .WithMany(d => d.Semesters)
       .HasForeignKey(d => d.AcademicYearId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicLevelIteration)
       .WithMany(d => d.Semesters)
       .HasForeignKey(d => d.AcademicLevelIterationId)
       .OnDelete(DeleteBehavior.Restrict);

    }
}
