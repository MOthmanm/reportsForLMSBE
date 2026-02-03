using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupQualificationConfiguration : BaseConfiguration<LookupQualification>
{
    public override void Configure(EntityTypeBuilder<LookupQualification> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المؤهلات العلمية");

        builder.Property(e => e.Id).HasComment("معرّف المؤهل");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}

