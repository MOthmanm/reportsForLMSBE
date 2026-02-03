using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupLanguageConfiguration : BaseConfiguration<LookupLanguage>
{
    public override void Configure(EntityTypeBuilder<LookupLanguage> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول اللغات");

        builder.HasData(
            new LookupLanguage { Id = 1, Code = "ar", NameAr = "العربية", NameEn = "Arabic", SortOrder = 1, IsActive = true },
            new LookupLanguage { Id = 2, Code = "en", NameAr = "الإنجليزية", NameEn = "English", SortOrder = 2, IsActive = true },
            new LookupLanguage { Id = 3, Code = "fr", NameAr = "الفرنسية", NameEn = "French", SortOrder = 3, IsActive = true }
        );
    }
}
