using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class JobConfiguration : BaseConfiguration<Job>
{
    public override void Configure(EntityTypeBuilder<Job> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Name).HasMaxLength(50);

        builder.HasOne(d => d.University)
               .WithMany(u => u.Jobs)
               .HasForeignKey(d => d.UniversityId)
               .OnDelete(DeleteBehavior.SetNull);

    }
}