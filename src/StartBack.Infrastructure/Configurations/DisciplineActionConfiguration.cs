using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class DisciplineActionConfiguration : BaseConfiguration<DisciplineAction>
{
    public override void Configure(EntityTypeBuilder<DisciplineAction> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الإجراءات التأديبية");

        builder.Property(e => e.Id).HasComment("معرّف الإجراء");
        builder.Property(e => e.IncidentId).HasComment("معرّف الحادثة");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الطالب بالجامعة");
        builder.Property(e => e.ActionTypeId).HasComment("معرّف نوع الإجراء");
        builder.Property(e => e.ActionDate).HasComment("تاريخ الإجراء");
        builder.Property(e => e.StartDate).HasComment("تاريخ البدء");
        builder.Property(e => e.EndDate).HasComment("تاريخ الانتهاء");
        builder.Property(e => e.DurationDays).HasComment("المدة بالأيام");
        builder.Property(e => e.Description).HasComment("وصف الإجراء");
        builder.Property(e => e.IssuedByPersonUniversityId).HasComment("صدر بواسطة (علاقة الموظف بالجامعة)");
        builder.Property(e => e.ParentNotified).HasComment("تم إشعار ولي الأمر");
        builder.Property(e => e.NotificationDate).HasComment("تاريخ الإشعار");
        builder.Property(e => e.Status).HasComment("الحالة");

        builder.HasOne(d => d.Incident)
               .WithMany()
               .HasForeignKey(d => d.IncidentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.PersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.ActionType)
               .WithMany()
               .HasForeignKey(d => d.ActionTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.IssuerPersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.IssuedByPersonUniversityId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
