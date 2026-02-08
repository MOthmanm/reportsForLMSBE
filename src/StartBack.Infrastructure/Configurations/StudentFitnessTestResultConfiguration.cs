using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StudentFitnessTestResultConfiguration : BaseConfiguration<StudentFitnessTestResult>
{
    public override void Configure(EntityTypeBuilder<StudentFitnessTestResult> builder)
    {
        base.Configure(builder);
        builder.ToTable("student_fitness_test_results");
        builder.HasComment("جدول تسجيل نتائج اختبارات اللياقة البدنية للطلبة على مستوى المادة والمحاضرة");

        builder.Property(e => e.Id).HasComment("المعرف الأساسي");
        builder.Property(e => e.UniversityId)
            .IsRequired()
            .HasComment("معرف الجامعة");
        builder.Property(e => e.AcademicYearId)
            .IsRequired()
            .HasComment("معرف العام الأكاديمي");
        builder.Property(e => e.CourseId)
            .IsRequired()
            .HasComment("معرف المادة");
        builder.Property(e => e.CourseSectionMeetingId)
            .IsRequired()
            .HasComment("معرف المحاضرة داخل المادة");
        builder.Property(e => e.StudentCourseEnrollmentId)
            .IsRequired()
            .HasComment("معرف تسجيل الطالب في مجموعة المادة");
        builder.Property(e => e.DegreeDivisionId)
            .IsRequired()
            .HasComment("معرف سطر تقسيم الدرجات الخاص باختبار اللياقة");
        builder.Property(e => e.ExerciseId)
            .IsRequired()
            .HasComment("معرف التمرين");
        builder.Property(e => e.AgeStageId)
            .HasComment("معرف المرحلة السنية المستخدمة في التقييم");
        builder.Property(e => e.EvaluationId)
            .HasComment("معرف شريحة التقييم المرجعية (اختياري)");
        builder.Property(e => e.AttemptNo)
            .IsRequired()
            .HasDefaultValue((short)1)
            .HasComment("رقم المحاولة لنفس التمرين في نفس المحاضرة");
        builder.Property(e => e.TestDatetime)
            .IsRequired()
            .HasDefaultValueSql("NOW()")
            .HasComment("تاريخ ووقت تنفيذ الاختبار");
        builder.Property(e => e.PerformedValue)
            .IsRequired()
            .HasPrecision(6, 2)
            .HasComment("القيمة المنفذة في الاختبار (عدد/زمن/مسافة حسب التمرين)");
        builder.Property(e => e.AchievedDegree)
            .HasPrecision(6, 2)
            .HasComment("الدرجة المستحقة من الاختبار");
        builder.Property(e => e.AchievedPercentage)
            .HasPrecision(5, 2)
            .HasComment("النسبة المئوية المستحقة");
        builder.Property(e => e.IsAbsent)
            .IsRequired()
            .HasDefaultValue(false)
            .HasComment("هل الطالب غائب في هذا الاختبار");
        builder.Property(e => e.Notes)
            .HasComment("ملاحظات إضافية على نتيجة الاختبار");
        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل السجل مفعل");

        builder.HasOne(d => d.University)
            .WithMany()
            .HasForeignKey(d => d.UniversityId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_university");

        builder.HasOne(d => d.AcademicYear)
            .WithMany()
            .HasForeignKey(d => d.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_academic_year");

        builder.HasOne(d => d.Course)
            .WithMany()
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_course");

        builder.HasOne(d => d.CourseSectionMeeting)
            .WithMany()
            .HasForeignKey(d => d.CourseSectionMeetingId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_meeting");

        builder.HasOne(d => d.StudentCourseEnrollment)
            .WithMany()
            .HasForeignKey(d => d.StudentCourseEnrollmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_student_enrollment");

        builder.HasOne(d => d.DegreeDivision)
            .WithMany()
            .HasForeignKey(d => d.DegreeDivisionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_degree_division");

        builder.HasOne(d => d.Exercise)
            .WithMany(p => p.StudentFitnessTestResults)
            .HasForeignKey(d => d.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_exercise");

        builder.HasOne(d => d.AgeStage)
            .WithMany(p => p.StudentFitnessTestResults)
            .HasForeignKey(d => d.AgeStageId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_student_fitness_result_age_stage");

        builder.HasOne(d => d.Evaluation)
            .WithMany(p => p.StudentFitnessTestResults)
            .HasForeignKey(d => d.EvaluationId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("fk_student_fitness_result_evaluation");

        builder.HasIndex(e => new { e.StudentCourseEnrollmentId, e.CourseSectionMeetingId, e.ExerciseId, e.AttemptNo })
            .IsUnique()
            .HasDatabaseName("uq_student_fitness_result_attempt");

        builder.HasIndex(e => e.UniversityId)
            .HasDatabaseName("ix_student_fitness_result_university");

        builder.HasIndex(e => e.AcademicYearId)
            .HasDatabaseName("ix_student_fitness_result_academic_year");

        builder.HasIndex(e => e.CourseId)
            .HasDatabaseName("ix_student_fitness_result_course");

        builder.HasIndex(e => e.CourseSectionMeetingId)
            .HasDatabaseName("ix_student_fitness_result_meeting");

        builder.HasIndex(e => e.StudentCourseEnrollmentId)
            .HasDatabaseName("ix_student_fitness_result_student_enrollment");

        builder.HasIndex(e => e.ExerciseId)
            .HasDatabaseName("ix_student_fitness_result_exercise");

        builder.HasCheckConstraint("ck_student_fitness_result_attempt_no", "attempt_no > 0");
        builder.HasCheckConstraint("ck_student_fitness_result_performed_value", "performed_value >= 0");
        builder.HasCheckConstraint("ck_student_fitness_result_achieved_degree", 
            "achieved_degree IS NULL OR achieved_degree >= 0");
        builder.HasCheckConstraint("ck_student_fitness_result_achieved_percentage", 
            "achieved_percentage IS NULL OR (achieved_percentage >= 0 AND achieved_percentage <= 100)");
    }
}

