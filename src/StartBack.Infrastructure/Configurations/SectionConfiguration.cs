using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class SectionConfiguration : BaseConfiguration<Section>
{
    public override void Configure(EntityTypeBuilder<Section> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الفصول والشعب الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف الشعبة");
        builder.Property(e => e.Name).HasComment("اسم الشعبة");
        builder.Property(e => e.Capacity).HasDefaultValue(0).HasComment("السعة القصوى");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");

        builder.HasOne(d => d.University)
               .WithMany(d=>d.Sections)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicLevel)
               .WithMany(d => d.Sections)
               .HasForeignKey(d => d.AcademicLevelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicYear)
               .WithMany(d => d.Sections)
               .HasForeignKey(d => d.AcademicYearId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicLevelIteration)
               .WithMany(d => d.Sections)
               .HasForeignKey(d => d.AcademicLevelIterationId)
               .OnDelete(DeleteBehavior.Restrict);


    }
}
