using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Contracts.enums;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class PersonUniversityConfiguration : BaseConfiguration<PersonUniversity>
{
    public override void Configure(EntityTypeBuilder<PersonUniversity> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول العلاقة بين الأشخاص والجامعات (Many-to-Many)");

        builder.Property(e => e.Id).HasComment("معرّف السجل");

        builder.Property(e => e.PersonId)
            .IsRequired()
            .HasComment("معرّف الشخص");

        builder.Property(e => e.UniversityId)
            .IsRequired()
            .HasComment("معرّف الجامعة");

        builder.Property(e => e.PersonType)
            .HasConversion<int>()
            .IsRequired()
            .HasComment("نوع الشخص في هذه الجامعة (موظف، طالب، موظف)");





        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل نشط");

        builder.Property(e => e.Notes)
            .HasMaxLength(500)
            .HasComment("ملاحظات");

        // Relationships
        builder.HasOne(d => d.Person)
               .WithMany(p => p.PersonUniversities)
               .HasForeignKey(d => d.PersonId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_person_university_person");

        builder.HasOne(d => d.University)
               .WithMany(u => u.PersonUniversities)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_person_university_university");

        builder.HasIndex(e => new { e.PersonId, e.UniversityId, e.PersonType })
            .IsUnique()
            .HasDatabaseName("ix_person_university_person_type_unique");
    }
}
