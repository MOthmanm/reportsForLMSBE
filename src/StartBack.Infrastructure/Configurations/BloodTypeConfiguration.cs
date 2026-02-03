using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class BloodTypeConfiguration : BaseConfiguration<BloodType>
{
    public override void Configure(EntityTypeBuilder<BloodType> entity)
    {
        base.Configure(entity);
        entity.HasComment("فصائل الدم");

        entity.Property(e => e.Id).HasComment("معرّف الدفعة");
        entity.Property(e => e.Code).HasComment("الرمز");
        entity.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        entity.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        entity.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        entity.Property(e => e.IsActive).HasComment("هل نشطة");

    }

}
