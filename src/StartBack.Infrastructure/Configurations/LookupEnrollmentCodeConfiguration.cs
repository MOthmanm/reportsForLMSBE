using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Entities.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupEnrollmentCodeConfiguration : BaseConfiguration<LookupEnrollmentCode>
{
    public override void Configure(EntityTypeBuilder<LookupEnrollmentCode> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أكواد القيد (دخول/خروج)");
        builder.Property(e => e.Id).HasComment("معرّف الكود");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");

        builder.HasData(
            new LookupEnrollmentCode { Id = 1, Code = "NEW", NameAr = "تسجيل جديد", NameEn = "New Enrollment", SortOrder = 1 },
            new LookupEnrollmentCode { Id = 3, Code = "GRADUATED", NameAr = "تخرج", NameEn = "Graduated",  SortOrder = 2 }
        );

    }
}
