using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseTypeConfiguration : BaseConfiguration<CourseType>
{
    public override void Configure(EntityTypeBuilder<CourseType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع المقررات");

        builder.HasData(
            new CourseType { Id = 1, Name = "مادة انضباطيه", ShowInCalendar = false, IsDeleted = false },
            new CourseType { Id = 2, Name = "مادة علميه", ShowInCalendar = true, IsDeleted = false },
            new CourseType { Id = 3, Name = "طابور", ShowInCalendar = true, IsDeleted = false }
        );

        builder.Property(e => e.Id).HasComment("معرّف نوع المقرر");
        builder.Property(e => e.Name).HasComment("الاسم");
        builder.Property(e => e.ShowInCalendar).HasComment("عرض في التقويم");
    }
}

