using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AcademicLevelCourseConfiguration : BaseConfiguration<AcademicLevelCourse>
{
    public override void Configure(EntityTypeBuilder<AcademicLevelCourse> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل نشط");

        // Relationships
        builder.HasOne(d => d.AcademicLevel)
               .WithMany(p => p.AcademicLevelCourses)
               .HasForeignKey(d => d.AcademicLevelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Course)
               .WithMany(u => u.AcademicLevelCourses)
               .HasForeignKey(d => d.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
