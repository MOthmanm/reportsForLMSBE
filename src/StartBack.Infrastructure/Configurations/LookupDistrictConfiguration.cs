using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupDistrictConfiguration : BaseConfiguration<LookupDistrict>
{
    public override void Configure(EntityTypeBuilder<LookupDistrict> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الأحياء/المناطق");

        builder.Property(e => e.Id).HasComment("معرّف الحي/المنطقة");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.GovernateId).HasComment("معرّف المحافظة");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

        builder.HasOne(d => d.Governate)
               .WithMany()
               .HasForeignKey(d => d.GovernateId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

