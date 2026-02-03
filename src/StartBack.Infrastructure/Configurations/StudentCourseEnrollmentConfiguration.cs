using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class StudentCourseEnrollmentConfiguration : BaseConfiguration<StudentCourseEnrollment>
{
    public override void Configure(EntityTypeBuilder<StudentCourseEnrollment> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول تسجيل الطلاب في حصص المقررات");

        builder.Property(e => e.Id).HasComment("معرّف التسجيل");
        builder.Property(e => e.StartDate).HasComment("تاريخ البدء");
        builder.Property(e => e.EndDate).HasComment("تاريخ الانتهاء");

        builder.HasOne(d => d.PersonUniversity)
               .WithMany(d=>d.StudentCourseEnrollments)
               .HasForeignKey(d => d.PersonUniversityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.CourseSemesterSection)
               .WithMany(d => d.StudentCourseEnrollments)
               .HasForeignKey(d => d.CourseSemesterSectionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.PersonUniversityId, e.CourseSemesterSectionId }).IsUnique();
    }
}
