using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupFitnessAgeStageConfiguration : BaseConfiguration<LookupFitnessAgeStage>
{
    public override void Configure(EntityTypeBuilder<LookupFitnessAgeStage> builder)
    {
        base.Configure(builder);
        builder.ToTable("lookup_fitness_age_stages");
        builder.HasComment("جدول تعريف المراحل السنية لاختبارات اللياقة البدنية");

        builder.Property(e => e.Id).HasComment("المعرف الأساسي");
        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(30)
            .HasComment("كود المرحلة السنية (فريد)");
        builder.Property(e => e.TitleAr)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("اسم المرحلة السنية بالعربية");
        builder.Property(e => e.TitleEn)
            .HasMaxLength(200)
            .HasComment("اسم المرحلة السنية بالإنجليزية");
        builder.Property(e => e.MinAge)
            .IsRequired()
            .HasComment("العمر الأدنى للمرحلة السنية");
        builder.Property(e => e.MaxAge)
            .IsRequired()
            .HasComment("العمر الأقصى للمرحلة السنية");
        builder.Property(e => e.SortOrder)
            .HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل المرحلة السنية مفعلة");

        builder.HasIndex(e => e.Code)
            .IsUnique()
            .HasDatabaseName("uq_lookup_fitness_age_stages_code");

        builder.HasCheckConstraint("ck_lookup_fitness_age_stages_min_age", "min_age >= 0");
        builder.HasCheckConstraint("ck_lookup_fitness_age_stages_max_age", "max_age >= min_age");
    }
}

