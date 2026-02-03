using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StudentGuardianConfiguration : BaseConfiguration<StudentGuardian>
{
    public override void Configure(EntityTypeBuilder<StudentGuardian> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول علاقة الطلاب بأولياء الأمور");

        builder.Property(e => e.Id).HasComment("معرّف العلاقة");
        builder.Property(e => e.PersonUniversityId).HasComment("معرّف علاقة الطالب بالجامعة");
        builder.Property(e => e.GuardianId).HasComment("معرّف ولي الأمر");
        builder.Property(e => e.RelationshipTypeId).HasComment("معرّف نوع العلاقة");
        builder.Property(e => e.IsPrimary).HasComment("هل ولي الأمر الأساسي");
        builder.Property(e => e.IsEmergencyContact).HasComment("جهة اتصال للطوارئ");
        builder.Property(e => e.CanPickup).HasComment("يمكنه استلام الطالب");
        builder.Property(e => e.HasCustody).HasComment("لديه حق الوصاية");
        builder.Property(e => e.ReceivesMailing).HasComment("يستلم المراسلات");

        builder.HasOne(d => d.PersonUniversity)
               .WithMany()
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Guardian)
               .WithMany()
               .HasForeignKey(d => d.GuardianId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.RelationshipType)
               .WithMany()
               .HasForeignKey(d => d.RelationshipTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.PersonUniversityId, e.GuardianId, e.RelationshipTypeId }).IsUnique();
    }
}
