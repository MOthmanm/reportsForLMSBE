using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class ProgressPeriodConfiguration : BaseConfiguration<ProgressPeriod>
{
    public override void Configure(EntityTypeBuilder<ProgressPeriod> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول فترات التقدم والتقييم المستمر");

        builder.Property(e => e.Id).HasComment("معرّف الفترة");
        builder.Property(e => e.QuarterId).HasComment("معرّف الربع");
        builder.Property(e => e.Title).HasComment("عنوان الفترة");
        builder.Property(e => e.ShortName).HasComment("الاسم المختصر");
        builder.Property(e => e.StartDate).HasComment("تاريخ البداية");
        builder.Property(e => e.EndDate).HasComment("تاريخ النهاية");
        builder.Property(e => e.DoesGrades).HasComment("هل تحسب درجات");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");

        builder.HasOne(d => d.Quarter)
               .WithMany()
               .HasForeignKey(d => d.QuarterId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
