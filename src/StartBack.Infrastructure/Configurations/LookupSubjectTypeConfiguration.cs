using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupSubjectTypeConfiguration : BaseConfiguration<LookupSubjectType>
{
    public override void Configure(EntityTypeBuilder<LookupSubjectType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع المواد الدراسية");

        builder.HasData(
            new LookupSubjectType { Id = 1, Code = "MANDATORY", NameAr = "إجباري", NameEn = "Mandatory", SortOrder = 1, IsActive = true },
            new LookupSubjectType { Id = 2, Code = "ELECTIVE", NameAr = "اختياري", NameEn = "Elective", SortOrder = 2, IsActive = true },
            new LookupSubjectType { Id = 3, Code = "ACTIVITY", NameAr = "نشاط", NameEn = "Activity", SortOrder = 3, IsActive = true },
            new LookupSubjectType { Id = 4, Code = "UNIVERSITY_REQ", NameAr = "متطلب جامعة", NameEn = "University Requirement", SortOrder = 4, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف النوع");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
