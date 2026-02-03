using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class AssignmentConfiguration : BaseConfiguration<Assignment>
{
    public override void Configure(EntityTypeBuilder<Assignment> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول التكليفات والواجبات الدراسية");

        builder.Property(e => e.Id).HasComment("معرّف التكليف");
        builder.Property(e => e.CourseSectionId).HasComment("معرّف حصة المقرر");
        builder.Property(e => e.AssignmentTypeId).HasComment("معرّف نوع التكليف");
        builder.Property(e => e.SemesterId).HasComment("معرّف الفصل الدراسي");
        builder.Property(e => e.QuarterId).HasComment("معرّف الربع");
        builder.Property(e => e.Title).HasComment("عنوان التكليف");
        builder.Property(e => e.Description).HasComment("وصف التكليف");
        builder.Property(e => e.AssignedDate).HasComment("تاريخ التكليف");
        builder.Property(e => e.DueDate).HasComment("تاريخ الاستحقاق");
        builder.Property(e => e.MaxPoints).HasComment("النقاط القصوى");
        builder.Property(e => e.IsExtraCredit).HasComment("هل هو درجات إضافية");
        builder.Property(e => e.IsGraded).HasComment("هل يتم تقييمه");
        builder.Property(e => e.CreatedBy).HasComment("تم الإنشاء بواسطة");


        builder.HasOne(d => d.CourseSection)
               .WithMany()
               .HasForeignKey(d => d.CourseSectionId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.AssignmentType)
               .WithMany()
               .HasForeignKey(d => d.AssignmentTypeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Semester)
               .WithMany()
               .HasForeignKey(d => d.SemesterId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Quarter)
               .WithMany()
               .HasForeignKey(d => d.QuarterId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
