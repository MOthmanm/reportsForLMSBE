using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class DisciplineIncidentStudentConfiguration : BaseConfiguration<DisciplineIncidentStudent>
{
    public override void Configure(EntityTypeBuilder<DisciplineIncidentStudent> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الطلاب المشاركين في حوادث السلوك");

        builder.Property(e => e.Id).HasComment("معرّف السجل");
        builder.Property(e => e.IncidentId).HasComment("معرّف الحادثة");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الطالب بالجامعة");
        builder.Property(e => e.Role).HasComment("دور الطالب");
        builder.Property(e => e.Notes).HasComment("ملاحظات");

        builder.HasOne(d => d.Incident)
               .WithMany()
               .HasForeignKey(d => d.IncidentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.PersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.IncidentId, e.PersonUniversityId, e.Role }).IsUnique();
    }
}
