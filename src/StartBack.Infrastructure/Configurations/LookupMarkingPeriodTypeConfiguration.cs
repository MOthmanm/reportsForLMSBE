using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupMarkingPeriodTypeConfiguration : BaseConfiguration<LookupMarkingPeriodType>
{
    public override void Configure(EntityTypeBuilder<LookupMarkingPeriodType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع فترات الرصد");

        builder.HasData(
            new LookupMarkingPeriodType { Id = 1, Code = "FINAL", NameAr = "نهائي", NameEn = "Final", SortOrder = 1, IsActive = true },
            new LookupMarkingPeriodType { Id = 2, Code = "MIDTERM", NameAr = "نصفي", NameEn = "Midterm", SortOrder = 2, IsActive = true },
            new LookupMarkingPeriodType { Id = 3, Code = "QUARTER", NameAr = "ربع سنوي", NameEn = "Quarterly", SortOrder = 3, IsActive = true },
            new LookupMarkingPeriodType { Id = 4, Code = "MONTHLY", NameAr = "شهري", NameEn = "Monthly", SortOrder = 4, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف النوع");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
