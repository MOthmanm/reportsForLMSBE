using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseSemesterConfiguration : BaseConfiguration<CourseSemester>
{
    public override void Configure(EntityTypeBuilder<CourseSemester> builder)
    {
        base.Configure(builder);
        builder.ToTable("course_semesters");
        builder.HasOne(d => d.Course)
               .WithMany(d => d.CourseSemesters)
               .HasForeignKey(d => d.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicLevelIteration)
            .WithMany(d => d.CourseSemesters)
            .HasForeignKey(d => d.AcademicLevelIterationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Semester)
            .WithMany(d => d.CourseSemesters)
            .HasForeignKey(d => d.SemesterId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}

