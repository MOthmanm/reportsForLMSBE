using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseInstructorConfiguration : BaseConfiguration<CourseInstructor>
{
    public override void Configure(EntityTypeBuilder<CourseInstructor> builder)
    {
        base.Configure(builder);
        // Relationships
        builder.HasOne(d => d.Course)
               .WithMany(p => p.CourseInstructors)
               .HasForeignKey(d => d.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.PersonUniversity)
               .WithMany(p => p.CourseInstructors)
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
