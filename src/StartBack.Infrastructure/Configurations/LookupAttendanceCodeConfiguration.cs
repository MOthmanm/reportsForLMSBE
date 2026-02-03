using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Entities.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupAttendanceCodeConfiguration : BaseConfiguration<LookupAttendanceCode>
{
    public override void Configure(EntityTypeBuilder<LookupAttendanceCode> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول أكواد الحضور");

        builder.HasData(
            new LookupAttendanceCode { Id = 1, Code = "P", NameAr = "حاضر", NameEn = "Present", ShortName = "ح", Type = AttendanceType.Present, DeductionPoints = 0, ColorCode = "#28a745", SortOrder = 1, IsDefault = true, IsActive = true },
            new LookupAttendanceCode { Id = 2, Code = "A", NameAr = "غائب", NameEn = "Absent", ShortName = "غ", Type = AttendanceType.Absent, DeductionPoints = 5, ColorCode = "#dc3545", SortOrder = 2, IsDefault = false, IsActive = true },
            new LookupAttendanceCode { Id = 3, Code = "T", NameAr = "متأخر", NameEn = "Tardy", ShortName = "م", Type = AttendanceType.Tardy, DeductionPoints = 1, ColorCode = "#ffc107", SortOrder = 3, IsDefault = false, IsActive = true },
            new LookupAttendanceCode { Id = 4, Code = "E", NameAr = "معذور", NameEn = "Excused", ShortName = "ع", Type = AttendanceType.Excused, DeductionPoints = 0, ColorCode = "#17a2b8", SortOrder = 4, IsDefault = false, IsActive = true },
            new LookupAttendanceCode { Id = 5, Code = "L", NameAr = "انصراف مبكر", NameEn = "Early Leave", ShortName = "ا", Type = AttendanceType.EarlyLeave, DeductionPoints = 2, ColorCode = "#fd7e14", SortOrder = 5, IsDefault = false, IsActive = true }
        );
        builder.Property(e => e.Id).HasComment("معرّف الكود");
        builder.Property(e => e.Code).HasComment("الرمز");
        builder.Property(e => e.NameAr).HasComment("الاسم بالعربية");
        builder.Property(e => e.NameEn).HasComment("الاسم بالإنجليزية");
        builder.Property(e => e.Type).HasComment("نوع الحضور");
        builder.Property(e => e.IsPresence).HasComment("هل يعتبر حضور");
        builder.Property(e => e.SortOrder).HasComment("ترتيب العرض");
        builder.Property(e => e.IsActive).HasComment("هل نشط");
    }
}
