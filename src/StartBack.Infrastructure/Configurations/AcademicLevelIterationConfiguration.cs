using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AcademicLevelIterationConfiguration : BaseConfiguration<AcademicLevelIteration>
{
    public override void Configure(EntityTypeBuilder<AcademicLevelIteration> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المستويات");

        builder.Property(e => e.Id).HasComment("معرّف المستوى");

        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.StartDate).HasComment("تاريخ البداية");
        builder.Property(e => e.EndDate).HasComment("تاريخ النهاية");

        builder.HasOne(d => d.AcademicLevel)
               .WithMany(d=>d.AcademicLevelIterations)
               .HasForeignKey(d => d.AcademicLevelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicYear)
       .WithMany(d => d.AcademicLevelIterations)
       .HasForeignKey(d => d.AcademicYearId)
       .OnDelete(DeleteBehavior.Restrict);





    }
}
