using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseSectionMeetingConfiguration : BaseConfiguration<CourseSectionMeeting>
{
    public override void Configure(EntityTypeBuilder<CourseSectionMeeting> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول مواعيد انعقاد المحاضرات الفعلية");

        builder.Property(e => e.Id).HasComment("معرّف الموعد");
        builder.Property(e => e.MeetingDate).HasComment("تاريخ المحاضرة");
        builder.Property(e => e.PeriodId).HasComment("معرّف الفترة الزمنية");
        builder.Property(e => e.HallId).HasComment("معرّف القاعة");
        builder.Property(e => e.CourseInstructorId).HasComment("معرّف مدرب المقرر");
        builder.Property(e => e.IsCancelled).HasComment("هل المحاضرة ملغية");
        builder.Property(e => e.CancelReason).HasComment("سبب الإلغاء");

        builder.HasOne(d => d.Hall)
               .WithMany(d=>d.CourseSectionMeetings)
               .HasForeignKey(d => d.HallId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Period)
               .WithMany(d => d.CourseSectionMeetings)
               .HasForeignKey(d => d.PeriodId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.CourseSemesterSection)
               .WithMany(d => d.CourseSectionMeetings)
               .HasForeignKey(d => d.CourseSemesterSectionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.CourseInstructor)
               .WithMany()
               .HasForeignKey(d => d.CourseInstructorId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

        builder.HasIndex(e => new { e.CourseSemesterSectionId, e.MeetingDate, e.PeriodId }).IsUnique();
    }
}
