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

        // ÇáÊÓßíä
        builder.HasOne(d => d.Building)
                .WithMany(p => p.StudentEnrollments)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Floor)
        .WithMany(p => p.StudentEnrollments)
        .HasForeignKey(d => d.FloorId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Room)
            .WithMany(p => p.StudentEnrollments)
            .HasForeignKey(d => d.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Battalion)
            .WithMany(p => p.StudentEnrollments)
            .HasForeignKey(d => d.BattalionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Company)
            .WithMany(p => p.StudentEnrollments)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Platoon)
            .WithMany(p => p.StudentEnrollments)
            .HasForeignKey(d => d.PlatoonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
