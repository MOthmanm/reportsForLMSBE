using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupEthnicityConfiguration : BaseConfiguration<LookupEthnicity>
{
    public override void Configure(EntityTypeBuilder<LookupEthnicity> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الأعراق");

        builder.HasData(
            new LookupEthnicity { Id = 1, Code = "ARAB", NameAr = "عربي", NameEn = "Arab", SortOrder = 1, IsActive = true },
            new LookupEthnicity { Id = 2, Code = "ASIAN", NameAr = "آسيوي", NameEn = "Asian", SortOrder = 2, IsActive = true },
            new LookupEthnicity { Id = 3, Code = "AFRICAN", NameAr = "أفريقي", NameEn = "African", SortOrder = 3, IsActive = true },
            new LookupEthnicity { Id = 4, Code = "EUROPEAN", NameAr = "أوروبي", NameEn = "European", SortOrder = 4, IsActive = true },
            new LookupEthnicity { Id = 5, Code = "OTHER", NameAr = "أخرى", NameEn = "Other", SortOrder = 5, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف العرق");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشطة");
    }
}
