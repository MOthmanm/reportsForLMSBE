using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupAttachmentTypeConfiguration : BaseConfiguration<LookupAttachmentType>
{
    public override void Configure(EntityTypeBuilder<LookupAttachmentType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع المرفقات");

        builder.Property(e => e.Id).HasComment("معرّف نوع المرفق");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}

