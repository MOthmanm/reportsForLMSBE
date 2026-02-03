using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Contracts.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class GuardianConfiguration : BaseConfiguration<Guardian>
{
    public override void Configure(EntityTypeBuilder<Guardian> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أولياء الأمور");

        builder.Property(e => e.Id).HasComment("معرّف ولي الأمر");
        builder.Property(e => e.Title).HasComment("اللقب");
        builder.Property(e => e.FirstName).HasComment("الاسم الأول");
        builder.Property(e => e.MiddleName).HasComment("الاسم الأوسط");
        builder.Property(e => e.LastName).HasComment("اسم العائلة");
        builder.Property(e => e.Gender)
            .HasConversion<int>()
            .HasComment("الجنس");
        builder.Property(e => e.Email).HasComment("البريد الإلكتروني");
        builder.Property(e => e.Phone).HasComment("رقم الهاتف");
        builder.Property(e => e.Mobile).HasComment("رقم الجوال");
        builder.Property(e => e.Address).HasComment("العنوان");
        builder.Property(e => e.Occupation).HasComment("المهنة");
        builder.Property(e => e.Workplace).HasComment("مكان العمل");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
