using StartBack.Application.DTOs.ReportColumn;
using StartBack.Application.DTOs.ReportParameter;
using StartBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartBack.Application.DTOs.Report
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? Description { get; set; }
        public string? Query { get; set; }
        public string? Path { get; set; }
        public string? Category { get; set; }
        public bool HasDetail { get; set; } = false;
        public bool Active { get; set; }
        public bool Hide { get; set; }
        public int? DetailId { get; set; }
        public string? DetailColumn { get; set; }
        public string? ReportType { get; set; } // 'table', 'crosstab', 'chart'

        public List<ReportColumnDto>? Columns { get; set; }
        public List<ReportParameterDto>? Parameters { get; set; }
    }
}
