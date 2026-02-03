using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AcademicCalendarConfiguration : BaseConfiguration<AcademicCalendar>
{
    public override void Configure(EntityTypeBuilder<AcademicCalendar> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول التقويمات الأكاديمية");

        builder.Property(e => e.Id).HasComment("معرّف التقويم");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.AcademicYearId).HasComment("معرّف السنة الدراسية");
        builder.Property(e => e.Title).HasComment("عنوان التقويم");
        builder.Property(e => e.IsDefault).HasComment("هل هو الافتراضي");
        builder.Property(e => e.RecurringDays).HasComment("أيام التكرار (JSON)");

        builder.HasOne(d => d.University)
               .WithMany(d=>d.AcademicCalendars)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.AcademicYear)
               .WithOne(d => d.AcademicCalendar)
               .HasForeignKey<AcademicCalendar>(d => d.AcademicYearId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
