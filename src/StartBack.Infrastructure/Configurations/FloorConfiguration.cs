using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class FloorConfiguration : BaseConfiguration<Floor>
{
    public override void Configure(EntityTypeBuilder<Floor> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الطوابق");

        builder.Property(e => e.Id).HasComment("معرّف الطابق");
        builder.Property(e => e.BuildingId).HasComment("معرّف المبنى");
        builder.Property(e => e.Code).HasMaxLength(50).HasComment("رمز الطابق");
        builder.Property(e => e.NameAr).HasMaxLength(200).HasComment("اسم الطابق بالعربية");
        builder.Property(e => e.NameEn).HasMaxLength(200).HasComment("اسم الطابق بالإنجليزية");
        builder.Property(e => e.Description).HasMaxLength(500).HasComment("وصف الطابق");
        builder.Property(e => e.IsActive).HasComment("هل نشط");

     

        builder.HasOne(d => d.Building)
               .WithMany(b => b.Floors)
               .HasForeignKey(d => d.BuildingId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}

