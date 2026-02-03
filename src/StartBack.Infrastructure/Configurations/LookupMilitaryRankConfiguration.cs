using Entities.Models.BaseConfiguration;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.Databases.PostgresDb.Configurations;

public class LookupMilitaryRankConfiguration : BaseConfiguration<LookupMilitaryRank>
{
    public override void Configure(EntityTypeBuilder<LookupMilitaryRank> builder)
    {
        base.Configure(builder);
        builder.HasComment("جدول الرتب العسكرية");

        builder.Property(e => e.Id).HasComment("معرّف الرتبة العسكرية");
        
        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("الرمز");
        
        builder.Property(e => e.NameAr)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("الاسم بالعربية");
        
        builder.Property(e => e.NameEn)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("الاسم بالإنجليزية");
        
        builder.Property(e => e.SortOrder)
            .IsRequired()
            .HasComment("ترتيب العرض");
        
        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("هل نشطة");

        // Seed data for military ranks (from lowest to highest)
        builder.HasData(
            // Enlisted Ranks (جنود وضباط صف)
            new LookupMilitaryRank { Id = 21, Code = "STD", NameAr = "طالب", NameEn = "Student", SortOrder = 1, IsActive = true },
            new LookupMilitaryRank { Id = 1, Code = "PVT", NameAr = "جندي", NameEn = "Private", SortOrder = 2, IsActive = true },
            new LookupMilitaryRank { Id = 2, Code = "CPL", NameAr = "عريف", NameEn = "Corporal", SortOrder = 3, IsActive = true },
            new LookupMilitaryRank { Id = 3, Code = "SGT", NameAr = "رقيب", NameEn = "Sergeant", SortOrder = 4, IsActive = true },
            new LookupMilitaryRank { Id = 4, Code = "SSGT", NameAr = "رقيب أول", NameEn = "Staff Sergeant", SortOrder = 5, IsActive = true },
            new LookupMilitaryRank { Id = 5, Code = "SFC", NameAr = "مساعد", NameEn = "Sergeant First Class", SortOrder = 6, IsActive = true },
            new LookupMilitaryRank { Id = 6, Code = "MSG", NameAr = "مساعد أول", NameEn = "Master Sergeant", SortOrder = 7, IsActive = true },
            
            // Officer Ranks (ضباط)
            new LookupMilitaryRank { Id = 10, Code = "LT", NameAr = "ملازم", NameEn = "Lieutenant", SortOrder = 10, IsActive = true },
            new LookupMilitaryRank { Id = 11, Code = "1LT", NameAr = "ملازم أول", NameEn = "First Lieutenant", SortOrder = 11, IsActive = true },
            new LookupMilitaryRank { Id = 12, Code = "CPT", NameAr = "نقيب", NameEn = "Captain", SortOrder = 12, IsActive = true },
            new LookupMilitaryRank { Id = 13, Code = "MAJ", NameAr = "رائد", NameEn = "Major", SortOrder = 13, IsActive = true },
            new LookupMilitaryRank { Id = 14, Code = "LTC", NameAr = "مقدم", NameEn = "Lieutenant Colonel", SortOrder = 14, IsActive = true },
            new LookupMilitaryRank { Id = 15, Code = "COL", NameAr = "عقيد", NameEn = "Colonel", SortOrder = 15, IsActive = true },
            new LookupMilitaryRank { Id = 16, Code = "BG", NameAr = "عميد", NameEn = "Brigadier General", SortOrder = 16, IsActive = true },
            new LookupMilitaryRank { Id = 17, Code = "MG", NameAr = "لواء", NameEn = "Major General", SortOrder = 17, IsActive = true },
            new LookupMilitaryRank { Id = 18, Code = "LTG", NameAr = "فريق", NameEn = "Lieutenant General", SortOrder = 18, IsActive = true },
            new LookupMilitaryRank { Id = 19, Code = "GEN", NameAr = "فريق أول", NameEn = "General", SortOrder = 19, IsActive = true },
            new LookupMilitaryRank { Id = 20, Code = "FM", NameAr = "مشير", NameEn = "Field Marshal", SortOrder = 20, IsActive = true }
        );
    }
}

