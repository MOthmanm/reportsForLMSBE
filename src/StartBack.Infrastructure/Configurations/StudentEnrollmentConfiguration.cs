using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StudentEnrollmentConfiguration : BaseConfiguration<StudentEnrollment>
{
    public override void Configure(EntityTypeBuilder<StudentEnrollment> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.IsCurrent).HasDefaultValue(false);
        // Relationships
        builder.HasOne(d => d.AcademicLevel)
               .WithMany(p => p.StudentEnrollments)
               .HasForeignKey(d => d.AcademicLevelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.PersonUniversity)
               .WithMany(u => u.StudentEnrollments)
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicYear)
               .WithMany()
               .HasForeignKey(d => d.AcademicYearId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Section)
               .WithMany()
               .HasForeignKey(d => d.SectionId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

        builder.HasOne(d => d.AcademicLevelIteration)
               .WithMany()
               .HasForeignKey(d => d.AcademicLevelIterationId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);
    }
}
