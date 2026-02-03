namespace StartBack.Application.DTOs.Report
{
    public class DropdownQueryRequest
    {
        public string Query { get; set; } = string.Empty;
    }

    public class DropdownOption
    {
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }
}
