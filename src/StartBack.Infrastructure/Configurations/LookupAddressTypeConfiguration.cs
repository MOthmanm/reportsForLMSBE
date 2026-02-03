using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupAddressTypeConfiguration : BaseConfiguration<LookupAddressType>
{
    public override void Configure(EntityTypeBuilder<LookupAddressType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع العناوين");

        builder.HasData(
            new LookupAddressType { Id = 1, Code = "HOME", NameAr = "المنزل", NameEn = "Home", SortOrder = 1, IsActive = true },
            new LookupAddressType { Id = 2, Code = "WORK", NameAr = "العمل", NameEn = "Work", SortOrder = 2, IsActive = true },
            new LookupAddressType { Id = 3, Code = "MAIL", NameAr = "المراسلات", NameEn = "Mailing", SortOrder = 3, IsActive = true }
        );
    }
}
