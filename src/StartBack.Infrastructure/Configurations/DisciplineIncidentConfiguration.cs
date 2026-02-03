using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class DisciplineIncidentConfiguration : BaseConfiguration<DisciplineIncident>
{
    public override void Configure(EntityTypeBuilder<DisciplineIncident> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول حوادث السلوك والانضباط");

        builder.Property(e => e.Id).HasComment("معرّف الحادثة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.AcademicYearId).HasComment("معرّف السنة الدراسية");
        builder.Property(e => e.IncidentCode).HasComment("رمز الحادثة");
        builder.Property(e => e.IncidentDate).HasComment("تاريخ الحادثة");
        builder.Property(e => e.IncidentTime).HasComment("وقت الحادثة");
        builder.Property(e => e.IncidentTypeId).HasComment("معرّف نوع الحادثة");
        builder.Property(e => e.Location).HasComment("المكان");
        builder.Property(e => e.Description).HasComment("وصف الحادثة");
        builder.Property(e => e.ReporterPersonUniversityId).HasComment("المبلغ (علاقة الموظف بالجامعة)");
        builder.Property(e => e.AssignedToId).HasComment("المسند إليه");
        builder.Property(e => e.Status).HasComment("الحالة");
        builder.Property(e => e.Resolution).HasComment("القرار");
        builder.Property(e => e.ResolvedAt).HasComment("تاريخ الحل");

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.AcademicYear)
               .WithMany()
               .HasForeignKey(d => d.AcademicYearId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.IncidentType)
               .WithMany()
               .HasForeignKey(d => d.IncidentTypeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.ReporterPersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.ReporterPersonUniversityId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
