using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupRecordStatusConfiguration : BaseConfiguration<LookupRecordStatus>
{
    public override void Configure(EntityTypeBuilder<LookupRecordStatus> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول حالات السجلات العامة");

        builder.HasData(
            new LookupRecordStatus { Id = 1, Code = "ACTIVE", NameAr = "نشط", NameEn = "Active", Description = "Active Record", SortOrder = 1, IsActive = true },
            new LookupRecordStatus { Id = 2, Code = "INACTIVE", NameAr = "غير نشط", NameEn = "Inactive", Description = "Inactive Record", SortOrder = 2, IsActive = true },
            new LookupRecordStatus { Id = 3, Code = "DELETED", NameAr = "محذوف", NameEn = "Deleted", Description = "Soft Deleted Record", SortOrder = 3, IsActive = true },
            new LookupRecordStatus { Id = 4, Code = "ARCHIVED", NameAr = "مؤرشف", NameEn = "Archived", Description = "Archived Record", SortOrder = 4, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف الحالة");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.Description).HasComment("الوصف");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
