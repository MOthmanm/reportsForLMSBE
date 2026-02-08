using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CompanyConfiguration : BaseConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول السرايا العسكرية");

        builder.Property(e => e.Id).HasComment("معرّف السرية");
        builder.Property(e => e.BattalionId).HasComment("معرّف الكتيبة");
        builder.Property(e => e.Code).HasMaxLength(50).HasComment("رمز السرية");
        builder.Property(e => e.NameAr).HasMaxLength(200).HasComment("اسم السرية بالعربية");
        builder.Property(e => e.NameEn).HasMaxLength(200).HasComment("اسم السرية بالإنجليزية");
        builder.Property(e => e.Description).HasMaxLength(500).HasComment("وصف السرية");
        builder.Property(e => e.IsActive).HasComment("هل نشط");


        builder.HasOne(d => d.Battalion)
               .WithMany(b => b.Companies)
               .HasForeignKey(d => d.BattalionId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
