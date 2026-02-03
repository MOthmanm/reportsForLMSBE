namespace StartBack.Application.DTOs.ReportParameter
{
    public class ReportParameterCreateDto
    {
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? DataType { get; set; }
        public string? ParameterType { get; set; }
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
        public string? QueryForDropdown { get; set; }
        public int? Sort { get; set; }
    }
}
