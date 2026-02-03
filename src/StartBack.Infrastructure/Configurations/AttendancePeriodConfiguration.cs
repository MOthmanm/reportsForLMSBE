using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AttendancePeriodConfiguration : BaseConfiguration<AttendancePeriod>
{
    public override void Configure(EntityTypeBuilder<AttendancePeriod> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الحضور بالحصة");

        builder.Property(e => e.Id).HasComment("معرّف السجل"); // Default
        builder.Property(e => e.CourseId).HasComment("معرّف المقرر");
        builder.Property(e => e.StudentCourseEnrollmentId).HasComment("معرّف تسجيل الطالب في المقرر");
        builder.Property(e => e.CourseSectionMeetingId).HasComment("معرّف موعد المحاضرة"); // Mapped from meeting ID
        builder.Property(e => e.AttendanceCodeId).HasComment("معرّف كود الحضور");
        builder.Property(e => e.Reason).HasComment("السبب");
        builder.Property(e => e.Comment).HasComment("ملاحظة");

        builder.HasOne(d => d.StudentCourseEnrollment)
               .WithMany(d => d.AttendancePeriods)
               .HasForeignKey(d => d.StudentCourseEnrollmentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.CourseSectionMeeting)
               .WithMany()
               .HasForeignKey(d => d.CourseSectionMeetingId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.AttendanceCode)
               .WithMany()
               .HasForeignKey(d => d.AttendanceCodeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => new { e.StudentCourseEnrollmentId, e.CourseSectionMeetingId }).IsUnique();
    }
}
