using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class QuarterConfiguration : BaseConfiguration<Quarter>
{
    public override void Configure(EntityTypeBuilder<Quarter> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الأرباع الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف الربع");
        builder.Property(e => e.SemesterId).HasComment("معرّف الفصل الدراسي");
        builder.Property(e => e.Title).HasComment("عنوان الربع");
        builder.Property(e => e.ShortName).HasComment("الاسم المختصر");
        builder.Property(e => e.StartDate).HasComment("تاريخ البداية");
        builder.Property(e => e.EndDate).HasComment("تاريخ النهاية");
        builder.Property(e => e.PostStartDate).HasComment("تاريخ بدء الرصد");
        builder.Property(e => e.PostEndDate).HasComment("تاريخ انتهاء الرصد");
        builder.Property(e => e.DoesGrades).HasComment("هل يحسب درجات");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");

        builder.HasOne(d => d.Semester)
               .WithMany()
               .HasForeignKey(d => d.SemesterId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
