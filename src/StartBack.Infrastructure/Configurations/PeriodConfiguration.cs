using Contracts.enums;
using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class PeriodConfiguration : BaseConfiguration<Period>
{
    public override void Configure(EntityTypeBuilder<Period> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الفترات الزمنية اليومية");

        builder.Property(e => e.Id).HasComment("معرّف الفترة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Title).HasComment("اسم الفترة");
        builder.Property(e => e.StartTime).HasComment("وقت البداية");
        builder.Property(e => e.EndTime).HasComment("وقت النهاية");
        builder.Property(e => e.LengthMinutes).HasComment("المدة بالدقائق");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.PeriodType).HasDefaultValue(PeriodType.Lecture).HasComment("نوع الفترة");
        builder.Property(e => e.IsAttendanceRequired).HasComment("الحضور مطلوب");
        builder.Property(e => e.IsActive).HasComment("هل نشطة");

        builder.HasOne(d => d.University)
               .WithMany(d=>d.Periods)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
