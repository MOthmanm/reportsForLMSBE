using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class PlatoonConfiguration : BaseConfiguration<Platoon>
{
    public override void Configure(EntityTypeBuilder<Platoon> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الفصائل العسكرية");

        builder.Property(e => e.Id).HasComment("معرّف الفصيل");
        builder.Property(e => e.CompanyId).HasComment("معرّف السرية");
        builder.Property(e => e.Code).HasMaxLength(50).HasComment("رمز الفصيل");
        builder.Property(e => e.NameAr).HasMaxLength(200).HasComment("اسم الفصيل بالعربية");
        builder.Property(e => e.NameEn).HasMaxLength(200).HasComment("اسم الفصيل بالإنجليزية");
        builder.Property(e => e.Description).HasMaxLength(500).HasComment("وصف الفصيل");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

        builder.HasOne(d => d.Company)
               .WithMany(c => c.Platoons)
               .HasForeignKey(d => d.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
