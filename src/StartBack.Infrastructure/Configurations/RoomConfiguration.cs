using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class RoomConfiguration : BaseConfiguration<Room>
{
    public override void Configure(EntityTypeBuilder<Room> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول القاعات والغرف");

        builder.Property(e => e.Id).HasComment("معرّف القاعة");
        builder.Property(e => e.UniversityId).HasComment("معرّف الجامعة");
        builder.Property(e => e.Code).HasComment("رمز القاعة");
        builder.Property(e => e.Title).HasComment("اسم القاعة");
        builder.Property(e => e.Building).HasComment("المبنى");
        builder.Property(e => e.Floor).HasComment("الطابق");
        builder.Property(e => e.Capacity).HasComment("السعة");
        builder.Property(e => e.IsActive).HasComment("هل نشطة");

        builder.HasOne(d => d.University)
               .WithMany()
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.UniversityId, e.Code }).IsUnique();
    }
}
