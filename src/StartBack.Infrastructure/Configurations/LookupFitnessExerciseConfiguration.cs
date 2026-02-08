using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupFitnessExerciseConfiguration : BaseConfiguration<LookupFitnessExercise>
{
    public override void Configure(EntityTypeBuilder<LookupFitnessExercise> builder)
    {
        base.Configure(builder);
        builder.ToTable("lookup_fitness_exercises");
        builder.HasComment("جدول تعريف تمارين اختبار اللياقة البدنية");

        builder.Property(e => e.Id).HasComment("المعرف الأساسي");
        builder.Property(e => e.DegreeDivisionId)
            .IsRequired()
            .HasComment("معرف سطر تقسيم الدرجات (اختبار اللياقة) من جدول degree-divisions");
        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(30)
            .HasComment("كود التمرين (فريد داخل نفس سطر تقسيم الدرجات)");
        builder.Property(e => e.TitleAr)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("اسم التمرين بالعربية");
        builder.Property(e => e.TitleEn)
            .HasMaxLength(200)
            .HasComment("اسم التمرين بالإنجليزية");
        builder.Property(e => e.UnitNameAr)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue("عدة")
            .HasComment("وحدة القياس بالعربية (مثال: عدة/ثانية/متر)");
        builder.Property(e => e.UnitNameEn)
            .HasMaxLength(50)
            .HasComment("وحدة القياس بالإنجليزية");
        builder.Property(e => e.MaxDegree)
            .HasPrecision(6, 2)
            .HasComment("الدرجة القصوى للتمرين");
        builder.Property(e => e.Description)
            .HasComment("وصف إضافي للتمرين");
        builder.Property(e => e.SortOrder)
            .HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل التمرين مفعل");

        builder.HasOne(d => d.DegreeDivision)
            .WithMany(p => p.FitnessExercises)
            .HasForeignKey(d => d.DegreeDivisionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_lookup_fitness_exercises_degree_division");

        builder.HasIndex(e => new { e.DegreeDivisionId, e.Code })
            .IsUnique()
            .HasDatabaseName("uq_lookup_fitness_exercises_degree_division_code");

        builder.HasIndex(e => e.DegreeDivisionId)
            .HasDatabaseName("ix_lookup_fitness_exercises_degree_division");

        builder.HasCheckConstraint("ck_lookup_fitness_exercises_max_degree", 
            "max_degree IS NULL OR max_degree >= 0");
    }
}

