using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupDisciplineActionTypeConfiguration : BaseConfiguration<LookupDisciplineActionType>
{
    public override void Configure(EntityTypeBuilder<LookupDisciplineActionType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع الإجراءات التأديبية");

        builder.HasData(
            new LookupDisciplineActionType { Id = 1, Code = "WARNING", NameAr = "إنذار", NameEn = "Warning", SortOrder = 1, IsActive = true },
            new LookupDisciplineActionType { Id = 2, Code = "DETENTION", NameAr = "احتجاز", NameEn = "Detention", SortOrder = 2, IsActive = true },
            new LookupDisciplineActionType { Id = 3, Code = "PARENT_MEETING", NameAr = "اجتماع مع ولي الأمر", NameEn = "Parent Meeting", SortOrder = 3, IsActive = true },
            new LookupDisciplineActionType { Id = 4, Code = "IN_UNIVERSITY_SUSP", NameAr = "إيقاف داخلي", NameEn = "In-University Suspension", SortOrder = 4, IsActive = true },
            new LookupDisciplineActionType { Id = 5, Code = "OUT_UNIVERSITY_SUSP", NameAr = "إيقاف خارجي", NameEn = "Out-of-University Suspension", SortOrder = 5, IsActive = true },
            new LookupDisciplineActionType { Id = 6, Code = "EXPULSION", NameAr = "فصل", NameEn = "Expulsion", SortOrder = 6, IsActive = true }
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
