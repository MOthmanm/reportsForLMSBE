using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class BattalionConfiguration : BaseConfiguration<Battalion>
{
    public override void Configure(EntityTypeBuilder<Battalion> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الكتائب العسكرية");

        builder.Property(e => e.Id).HasComment("معرّف الكتيبة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Code).HasMaxLength(50).HasComment("رمز الكتيبة");
        builder.Property(e => e.NameAr).HasMaxLength(200).HasComment("اسم الكتيبة بالعربية");
        builder.Property(e => e.NameEn).HasMaxLength(200).HasComment("اسم الكتيبة بالإنجليزية");
        builder.Property(e => e.Description).HasMaxLength(500).HasComment("وصف الكتيبة");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.UniversityId, e.Code }).IsUnique();
    }
}
