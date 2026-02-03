using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupRelationshipTypeConfiguration : BaseConfiguration<LookupRelationshipType>
{
    public override void Configure(EntityTypeBuilder<LookupRelationshipType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع العلاقات (ولي الأمر)");

        builder.HasData(
            new LookupRelationshipType { Id = 1, Code = "FATHER", NameAr = "الأب", NameEn = "Father", SortOrder = 1, IsActive = true },
            new LookupRelationshipType { Id = 2, Code = "MOTHER", NameAr = "الأم", NameEn = "Mother", SortOrder = 2, IsActive = true },
            new LookupRelationshipType { Id = 3, Code = "GUARDIAN", NameAr = "ولي الأمر", NameEn = "Guardian", SortOrder = 3, IsActive = true },
            new LookupRelationshipType { Id = 4, Code = "GRANDPARENT", NameAr = "الجد/الجدة", NameEn = "Grandparent", SortOrder = 4, IsActive = true },
            new LookupRelationshipType { Id = 5, Code = "SIBLING", NameAr = "الأخ/الأخت", NameEn = "Sibling", SortOrder = 5, IsActive = true },
            new LookupRelationshipType { Id = 6, Code = "OTHER", NameAr = "أخرى", NameEn = "Other", SortOrder = 6, IsActive = true }
        );
    }
}
