using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CalendarDayConfiguration : BaseConfiguration<AcademicCalendarDetail>
{
    public override void Configure(EntityTypeBuilder<AcademicCalendarDetail> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أيام التقويم الأكاديمي");

        builder.Property(e => e.Id).HasComment("معرّف اليوم");
        builder.Property(e => e.AcademicCalendarId).HasComment("معرّف التقويم");
        builder.Property(e => e.AcademicDate).HasComment("التاريخ");
        builder.Property(e => e.Notes).HasComment("ملاحظات (مثل: إجازة 6 أكتوبر)");

        builder.HasOne(d => d.AcademicCalendar)
               .WithMany(d=>d.AcademicCalendarDetails)
               .HasForeignKey(d => d.AcademicCalendarId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.AcademicCalendarId, e.AcademicDate }).IsUnique();
    }
}
