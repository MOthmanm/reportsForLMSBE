using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupNationalityConfiguration : BaseConfiguration<LookupNationality>
{
    public override void Configure(EntityTypeBuilder<LookupNationality> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الجنسيات");

        builder.HasData(
            new LookupNationality { Id = 1, Code = "SA", NameAr = "سعودي", NameEn = "Saudi", CountryCode = "SA", SortOrder = 1, IsActive = true },
            new LookupNationality { Id = 2, Code = "EG", NameAr = "مصري", NameEn = "Egyptian", CountryCode = "EG", SortOrder = 2, IsActive = true },
            new LookupNationality { Id = 3, Code = "YE", NameAr = "يمني", NameEn = "Yemeni", CountryCode = "YE", SortOrder = 3, IsActive = true },
            new LookupNationality { Id = 4, Code = "SY", NameAr = "سوري", NameEn = "Syrian", CountryCode = "SY", SortOrder = 4, IsActive = true },
            new LookupNationality { Id = 5, Code = "JO", NameAr = "أردني", NameEn = "Jordanian", CountryCode = "JO", SortOrder = 5, IsActive = true },
            new LookupNationality { Id = 99, Code = "OTH", NameAr = "أخرى", NameEn = "Other", CountryCode = "OTH", SortOrder = 99, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف الجنسية");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.CountryCode).HasComment("رمز الدولة");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشطة");
    }
}
