using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AcademicYearConfiguration : BaseConfiguration<AcademicYear>
{
    public override void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول السنوات الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف السنة الدراسية");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Title).IsRequired().HasMaxLength(100).HasComment("عنوان السنة الدراسية");
        builder.Property(e => e.ShortName).IsRequired().HasMaxLength(20).HasComment("الاسم المختصر");
        builder.Property(e => e.StartDate).HasComment("تاريخ البداية");
        builder.Property(e => e.EndDate).HasComment("تاريخ النهاية");
        builder.Property(e => e.IsCurrent).HasComment("هل السنة الحالية");


        builder.HasOne(d => d.University)
               .WithMany(d=>d.AcademicYears)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
