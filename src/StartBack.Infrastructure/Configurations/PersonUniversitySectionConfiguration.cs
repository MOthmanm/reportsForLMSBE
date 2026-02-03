using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class PersonUniversitySectionConfiguration : BaseConfiguration<PersonUniversitySection>
{
    public override void Configure(EntityTypeBuilder<PersonUniversitySection> builder)
    {
        base.Configure(builder);

        // Relationships
        builder.HasOne(d => d.PersonUniversity)
               .WithMany(p => p.PersonUniversitySections)
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Section)
       .WithMany(p => p.PersonUniversitySections)
       .HasForeignKey(d => d.SectionId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.AcademicYear)
       .WithMany(p => p.PersonUniversitySections)
       .HasForeignKey(d => d.AcademicYearId)
       .OnDelete(DeleteBehavior.Restrict);


    }
}