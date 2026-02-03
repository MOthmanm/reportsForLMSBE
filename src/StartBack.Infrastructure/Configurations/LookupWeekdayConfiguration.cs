using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupWeekdayConfiguration : BaseConfiguration<LookupWeekday>
{
    public override void Configure(EntityTypeBuilder<LookupWeekday> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أيام الأسبوع");

        builder.HasData(
            new LookupWeekday { Id = 1, Code = "SUN", NameAr = "الأحد", NameEn = "Sunday", SortOrder = 1, IsActive = true },
            new LookupWeekday { Id = 2, Code = "MON", NameAr = "الاثنين", NameEn = "Monday", SortOrder = 2, IsActive = true },
            new LookupWeekday { Id = 3, Code = "TUE", NameAr = "الثلاثاء", NameEn = "Tuesday", SortOrder = 3, IsActive = true },
            new LookupWeekday { Id = 4, Code = "WED", NameAr = "الأربعاء", NameEn = "Wednesday", SortOrder = 4, IsActive = true },
            new LookupWeekday { Id = 5, Code = "THU", NameAr = "الخميس", NameEn = "Thursday", SortOrder = 5, IsActive = true },
            new LookupWeekday { Id = 6, Code = "FRI", NameAr = "الجمعة", NameEn = "Friday", SortOrder = 6, IsActive = true },
            new LookupWeekday { Id = 7, Code = "SAT", NameAr = "السبت", NameEn = "Saturday", SortOrder = 7, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف اليوم");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض (الأحد=1)");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
