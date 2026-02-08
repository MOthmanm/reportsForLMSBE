using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupFitnessExerciseEvaluationConfiguration : BaseConfiguration<LookupFitnessExerciseEvaluation>
{
    public override void Configure(EntityTypeBuilder<LookupFitnessExerciseEvaluation> builder)
    {
        base.Configure(builder);
        builder.ToTable("lookup_fitness_exercise_evaluations");
        builder.HasComment("جدول ربط تقييم الدرجة/العدة لكل تمرين حسب المرحلة السنية بالنسبة المئوية");

        builder.Property(e => e.Id).HasComment("المعرف الأساسي");
        builder.Property(e => e.UniversityId)
            .IsRequired()
            .HasComment("معرف الجامعة");
        builder.Property(e => e.AcademicYearId)
            .IsRequired()
            .HasComment("معرف العام الأكاديمي");
        builder.Property(e => e.AgeStageId)
            .IsRequired()
            .HasComment("معرف المرحلة السنية");
        builder.Property(e => e.ExerciseId)
            .IsRequired()
            .HasComment("معرف التمرين");
        builder.Property(e => e.DegreeValue)
            .IsRequired()
            .HasPrecision(6, 2)
            .HasComment("الدرجة أو عدد العدات المقابل للتقييم");
        builder.Property(e => e.PercentageValue)
            .IsRequired()
            .HasPrecision(5, 2)
            .HasComment("النسبة المئوية المقابلة للدرجة");
        builder.Property(e => e.SortOrder)
            .HasComment("ترتيب العرض داخل التمرين");
        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل التقييم مفعل");

        builder.HasOne(d => d.University)
            .WithMany()
            .HasForeignKey(d => d.UniversityId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_fitness_eval_university");

        builder.HasOne(d => d.AcademicYear)
            .WithMany()
            .HasForeignKey(d => d.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_fitness_eval_academic_year");

        builder.HasOne(d => d.AgeStage)
            .WithMany(p => p.ExerciseEvaluations)
            .HasForeignKey(d => d.AgeStageId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_fitness_eval_age_stage");

        builder.HasOne(d => d.Exercise)
            .WithMany(p => p.ExerciseEvaluations)
            .HasForeignKey(d => d.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_fitness_eval_exercise");

        builder.HasIndex(e => new { e.UniversityId, e.AcademicYearId, e.AgeStageId, e.ExerciseId, e.DegreeValue })
            .IsUnique()
            .HasDatabaseName("uq_lookup_fitness_exercise_eval");

        builder.HasIndex(e => e.UniversityId)
            .HasDatabaseName("ix_lookup_fitness_exercise_eval_university");

        builder.HasIndex(e => e.AcademicYearId)
            .HasDatabaseName("ix_lookup_fitness_exercise_eval_academic_year");

        builder.HasIndex(e => e.AgeStageId)
            .HasDatabaseName("ix_lookup_fitness_exercise_eval_age_stage");

        builder.HasIndex(e => e.ExerciseId)
            .HasDatabaseName("ix_lookup_fitness_exercise_eval_exercise");

        builder.HasCheckConstraint("ck_lookup_fitness_exercise_eval_degree", "degree_value >= 0");
        builder.HasCheckConstraint("ck_lookup_fitness_exercise_eval_percentage", 
            "percentage_value >= 0 AND percentage_value <= 100");
    }
}

