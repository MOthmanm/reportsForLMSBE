using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupStaffCategoryConfiguration : BaseConfiguration<LookupStaffCategory>
{
    public override void Configure(EntityTypeBuilder<LookupStaffCategory> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول فئات الموظفين");

        builder.HasData(
            new LookupStaffCategory { Id = 1, Code = "ACADEMIC", NameAr = "هيئة تدريس", NameEn = "Academic", IsAcademic = true, SortOrder = 1, IsActive = true },
            new LookupStaffCategory { Id = 2, Code = "ADMIN", NameAr = "اداري", NameEn = "Administrative", IsAcademic = false, SortOrder = 2, IsActive = true },
            new LookupStaffCategory { Id = 3, Code = "TECH", NameAr = "فني", NameEn = "Technician", IsAcademic = false, SortOrder = 3, IsActive = true },
            new LookupStaffCategory { Id = 4, Code = "WORKER", NameAr = "عامل", NameEn = "Worker", IsAcademic = false, SortOrder = 4, IsActive = true }
        );

        builder.Property(e => e.Id).HasComment("معرّف الفئة");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.IsAcademic).HasComment("هل هيئة تدريس");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
