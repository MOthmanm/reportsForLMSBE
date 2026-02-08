using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class BuildingConfiguration : BaseConfiguration<Building>
{
    public override void Configure(EntityTypeBuilder<Building> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المباني");

        builder.Property(e => e.Id).HasComment("معرّف المبنى");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Code).HasMaxLength(50).HasComment("رمز المبنى");
        builder.Property(e => e.NameAr).HasMaxLength(200).HasComment("اسم المبنى بالعربية");
        builder.Property(e => e.NameEn).HasMaxLength(200).HasComment("اسم المبنى بالإنجليزية");
        builder.Property(e => e.Description).HasMaxLength(500).HasComment("وصف المبنى");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.UniversityId, e.Code }).IsUnique();
    }
}

