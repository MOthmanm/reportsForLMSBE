using Entities.Models.BaseTables;

namespace Entities.Models.Tables;

// Ïå ÚÈÇÑÉ Úä ÊÓßíä ÇáßæÑÓÇÊ ÇáÊÚáíãíå Úáì ÇáãÓÊæíÇÊ ÇáÊÚáíãíÉ
public class AcademicLevelCourse : BaseTable
{
    public int AcademicLevelId { get; set; }
    public int CourseId { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual AcademicLevel? AcademicLevel  { get; set; }
    public virtual Course? Course { get; set; }



}

