using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class GradeScaleItemConfiguration : BaseConfiguration<GradeScaleItem>
{
    public override void Configure(EntityTypeBuilder<GradeScaleItem> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول رموز التقديرات");

        builder.Property(e => e.Id).HasComment("معرّف الرمز");
        builder.Property(e => e.GradeScaleId).HasComment("معرّف المقياس");
        builder.Property(e => e.Title).HasComment("رمز التقدير");
        builder.Property(e => e.MinPercent).HasComment("الحد الأدنى للنسبة");
        builder.Property(e => e.MaxPercent).HasComment("الحد الأقصى للنسبة");

        builder.HasOne(d => d.GradeScale)
               .WithMany(d=>d.GradeScaleItems)
               .HasForeignKey(d => d.GradeScaleId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
