using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupPhoneTypeConfiguration : BaseConfiguration<LookupPhoneType>
{
    public override void Configure(EntityTypeBuilder<LookupPhoneType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع الهواتف");

        builder.HasData(
            new LookupPhoneType { Id = 1, Code = "MOBILE", NameAr = "جوال", NameEn = "Mobile", SortOrder = 1, IsActive = true },
            new LookupPhoneType { Id = 2, Code = "HOME", NameAr = "منزل", NameEn = "Home", SortOrder = 2, IsActive = true },
            new LookupPhoneType { Id = 3, Code = "WORK", NameAr = "عمل", NameEn = "Work", SortOrder = 3, IsActive = true },
            new LookupPhoneType { Id = 4, Code = "EMERGENCY", NameAr = "طوارئ", NameEn = "Emergency", SortOrder = 4, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف النوع");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
