namespace StartBack.Domain.Entities
{
    public class Report : BaseEntity
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? Description { get; set; }
        public string? Query { get; set; }
        public string? Path { get; set; }
        public string? Category { get; set; }
        public bool HasDetail { get; set; } = false;
        public bool Active { get; set; } = true;
        public bool Hide { get; set; } = false;
        public int? DetailId { get; set; }
        public string? DetailColumn { get; set; }
        public string? ReportType { get; set; } // 'table', 'crosstab', 'chart'
        public List<ReportColumn>? Columns { get; set; }
        public List<ReportParameter>? Parameters { get; set; }

    }
}