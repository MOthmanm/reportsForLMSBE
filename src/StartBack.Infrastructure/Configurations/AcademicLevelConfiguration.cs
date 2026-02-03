using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AcademicLevelConfiguration : BaseConfiguration<AcademicLevel>
{
    public override void Configure(EntityTypeBuilder<AcademicLevel> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول المستويات");

        builder.Property(e => e.Id).HasComment("معرّف المستوى");
        builder.Property(e => e.UniversityId).IsRequired().HasComment("معرّف الجامعة");
        builder.Property(e => e.ParentId).HasComment("معرّف المستوى الأب");
        builder.Property(e => e.Title).HasMaxLength(100).HasComment("اسم المستوى");
        builder.Property(e => e.ShortName).HasMaxLength(20).HasComment("الاسم المختصر");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Parent)
               .WithMany(d => d.Children)
               .HasForeignKey(d => d.ParentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.NextLevel)
               .WithMany()
               .HasForeignKey(d => d.NextLevelId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.PreviousLevel)
       .WithMany()
       .HasForeignKey(d => d.PreviousLevelId)
       .OnDelete(DeleteBehavior.SetNull);

    }
}
