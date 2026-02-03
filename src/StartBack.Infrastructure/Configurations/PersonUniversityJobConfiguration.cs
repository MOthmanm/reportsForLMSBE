using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class PersonUniversityJobConfiguration : BaseConfiguration<PersonUniversityJob>
{
    public override void Configure(EntityTypeBuilder<PersonUniversityJob> builder)
    {
        base.Configure(builder);
        builder.Property(e=>e.IsCurrent).HasDefaultValue(false);
        // Relationships
        builder.HasOne(d => d.Job)
               .WithMany(p => p.PersonUniversityJobs)
               .HasForeignKey(d => d.JobId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.PersonUniversity)
               .WithMany(u => u.PersonUniversityJobs)
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
