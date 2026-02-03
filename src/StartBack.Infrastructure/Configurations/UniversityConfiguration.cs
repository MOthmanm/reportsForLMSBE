using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class UniversityConfiguration : BaseConfiguration<University>
{
    public override void Configure(EntityTypeBuilder<University> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الجامعات والمؤسسات الأكاديمية");

        builder.Property(e => e.Id).HasComment("معرّف الجامعة");
        builder.Property(e => e.NameAr).HasMaxLength(200).HasComment("اسم الجامعة بالعربية");
        builder.Property(e => e.NameEn).HasMaxLength(200).HasComment("اسم الجامعة بالإنجليزية");
        builder.Property(e => e.ShortName).HasMaxLength(50).HasComment("الاسم المختصر");
        builder.Property(e => e.ParentId).HasComment("المستوي الاعلي");

        builder.Property(e => e.Level)
            .HasComment("المستوي");

        builder.Property(e => e.Icon)
        .HasMaxLength(150)
        .HasComment("الايقونة");


        builder.HasOne(d => d.Parent)
            .WithMany(p => p.Childern)
            .HasForeignKey(d => d.ParentId);
        builder.Property(e => e.IsActive).HasComment("هل نشطة");
    }
}
