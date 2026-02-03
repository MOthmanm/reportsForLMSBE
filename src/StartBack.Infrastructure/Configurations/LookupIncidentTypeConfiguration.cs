using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupIncidentTypeConfiguration : BaseConfiguration<LookupIncidentType>
{
    public override void Configure(EntityTypeBuilder<LookupIncidentType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع حوادث السلوك");

        builder.HasData(
            new LookupIncidentType { Id = 1, Code = "TARDINESS", NameAr = "التأخر", NameEn = "Tardiness", SeverityLevel = 1, SortOrder = 1, IsActive = true },
            new LookupIncidentType { Id = 2, Code = "DISRUPTIVE", NameAr = "السلوك التخريبي", NameEn = "Disruptive Behavior", SeverityLevel = 2, SortOrder = 2, IsActive = true },
            new LookupIncidentType { Id = 3, Code = "VERBAL_ABUSE", NameAr = "الإساءة اللفظية", NameEn = "Verbal Abuse", SeverityLevel = 3, SortOrder = 3, IsActive = true },
            new LookupIncidentType { Id = 4, Code = "BULLYING", NameAr = "التنمر", NameEn = "Bullying", SeverityLevel = 4, SortOrder = 4, IsActive = true },
            new LookupIncidentType { Id = 5, Code = "PHYSICAL", NameAr = "العنف الجسدي", NameEn = "Physical Violence", SeverityLevel = 5, SortOrder = 5, IsActive = true },
            new LookupIncidentType { Id = 6, Code = "CHEATING", NameAr = "الغش", NameEn = "Cheating", SeverityLevel = 3, SortOrder = 6, IsActive = true }
        );
        builder.Property(e => e.Id).HasComment("معرّف النوع");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.SeverityLevel).HasComment("الخطورة (1-5)");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
