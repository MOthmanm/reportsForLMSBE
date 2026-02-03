using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AssignmentTypeConfiguration : BaseConfiguration<AssignmentType>
{
    public override void Configure(EntityTypeBuilder<AssignmentType> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أنواع التكليفات والواجبات");

        builder.Property(e => e.Id).HasComment("معرّف النوع");
        builder.Property(e => e.CourseSectionId).HasComment("معرّف حصة المقرر");
        builder.Property(e => e.Title).HasComment("عنوان النوع");
        builder.Property(e => e.WeightPercent).HasComment("النسبة المئوية");
        builder.Property(e => e.DefaultPoints).HasComment("النقاط الافتراضية");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");

        builder.HasOne(d => d.CourseSection)
               .WithMany()
               .HasForeignKey(d => d.CourseSectionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
