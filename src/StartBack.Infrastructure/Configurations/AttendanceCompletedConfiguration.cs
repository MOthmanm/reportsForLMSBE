using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AttendanceCompletedConfiguration : BaseConfiguration<AttendanceCompleted>
{
    public override void Configure(EntityTypeBuilder<AttendanceCompleted> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول حالة إتمام تسجيل الحضور");

        builder.Property(e => e.Id).HasComment("معرّف السجل");
        builder.Property(e => e.CourseSectionMeetingId).HasComment("معرّف موعد المحاضرة");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الموظف بالجامعة");

        builder.HasOne(d => d.CourseSectionMeeting)
               .WithOne() // 1-to-1 implied by UNIQUE constraint in SQL
               .HasForeignKey<AttendanceCompleted>(d => d.CourseSectionMeetingId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.PersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
