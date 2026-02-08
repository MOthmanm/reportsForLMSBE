using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class HallConfiguration : BaseConfiguration<Hall>
{
    public override void Configure(EntityTypeBuilder<Hall> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول القاعات والغرف");

        builder.Property(e => e.Id).HasComment("معرّف القاعة");
        builder.Property(e => e.Code).HasComment("رمز القاعة");
        builder.Property(e => e.Title).HasComment("اسم القاعة");
        builder.Property(e => e.Capacity).HasComment("السعة");
        builder.Property(e => e.IsActive).HasComment("هل نشطة");

    }
}
