using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseDegreeDevisionCourseConfiguration : BaseConfiguration<CourseDegreeDevisionCourse>
{
    public override void Configure(EntityTypeBuilder<CourseDegreeDevisionCourse> builder)
    {
        base.Configure(builder);
        // Relationships
        builder.HasOne(d => d.Course)
               .WithMany(p => p.CourseDegreeDevisionCourses)
               .HasForeignKey(d => d.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.LookupCourseDegreeDevision)
               .WithMany(p => p.CourseDegreeDevisionCourses)
               .HasForeignKey(d => d.LookupCourseDegreeDevisionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}