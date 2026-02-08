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

        builder.Property(e => e.Id).HasComment("معرّف العنبر");
        builder.Property(e => e.FloorId).HasComment("معرّف الطابق");
        builder.Property(e => e.Code).HasComment("رمز العنبر");
        builder.Property(e => e.Title).HasComment("اسم العنبر");
        builder.Property(e => e.Capacity).HasComment("السعة");
        builder.Property(e => e.IsActive).HasComment("هل نشطة");
        builder.HasOne(d => d.Floor)
               .WithMany(f => f.Rooms)
               .HasForeignKey(d => d.FloorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
