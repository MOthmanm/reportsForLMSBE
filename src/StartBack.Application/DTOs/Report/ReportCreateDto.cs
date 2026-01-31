using StartBack.Domain.Entities;

namespace StartBack.Application.DTOs.Report
{
    public class ReportCreateDto
    {

        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? Description { get; set; }
        public string? Query { get; set; }
        public string? Path { get; set; }
        public string? Category { get; set; }
        public bool HasDetail { get; set; } = false;
        public int? DetailId { get; set; }
        public string? DetailColumn { get; set; }


    }
}