using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class CourseSemesterSectionConfiguration : BaseConfiguration<CourseSemesterSection>
{
    public override void Configure(EntityTypeBuilder<CourseSemesterSection> builder)
    {
        base.Configure(builder);


        builder.HasOne(d => d.Section)
               .WithMany(d => d.CourseSemesterSections)
               .HasForeignKey(d => d.SectionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.CourseSemester)
            .WithMany(d => d.CourseSemesterSections)
            .HasForeignKey(d => d.CourseSemesterId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}

