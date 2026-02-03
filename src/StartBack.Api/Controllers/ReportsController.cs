using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using StartBack.Application.Services;
using StartBack.Application.DTOs.Report;
using StartBack.Application.DTOs.ReportColumn;
using StartBack.Domain.Exceptions;
using StartBack.Domain.Helpers;
using StartBack.Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using StartBack.Application.Abstractions;
using StartBack.Application.DTOs.ReportParameter;

namespace StartBack.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/reports")]
    //[Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;
        private readonly PostgreSqlExecutor _postgreExecutor;
        private readonly IPermissionService _permissionService;
        private readonly IUserService _userService;


        public ReportsController(ReportService reportService, PostgreSqlExecutor postgreExecutor, IPermissionService permissionService, IUserService userService)
        {
            _reportService = reportService;
            _postgreExecutor = postgreExecutor;
            _permissionService = permissionService;
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetAll([FromQuery] FindOptions options)
        {
            var reports = await _reportService.GetAllAsync(options);
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> Get(int id)
        {
            var report = await _reportService.GetByIdAsync(id);
            if (report == null) return NotFound();
            return Ok(report);
        }


        [HttpPost]
        public async Task<ActionResult<ReportDto>> Create([FromBody] ReportCreateDto dto)
        {
            var created = await _reportService.CreateAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReportUpdateDto dto)
        {
            await _reportService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reportService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("dashboard-reports")]
        public async Task<ActionResult<List<string>>> GetDashboardReports()
        {
            var dashboardReportsNames = await _reportService.GetDashboardNames();
            return Ok(dashboardReportsNames);
        }

        [HttpGet("reports-from-permissions")]
        [Authorize]
        public async Task<ActionResult<PaginatedResult<ReportDto>>> GetReportsFromPermissions([FromQuery] int page = 1, [FromQuery] int pageSize = 20,
            [FromQuery] string? search = null, [FromQuery] string? sortBy = null, [FromQuery] bool desc = false)
        {
            var permissionClaims = User.FindAll("perm").Select(c => c.Value).ToList();

            if (!permissionClaims.Any())
            {
                return Ok(new PaginatedResult<ReportDto>
                {
                    Items = new List<ReportDto>(),
                    Page = page,
                    PageSize = pageSize,
                    Total = 0
                });
            }

            var allowedReportNames = new List<string>();
            foreach (var permission in permissionClaims)
            {
                if (permission.StartsWith("Reports.") && permission.EndsWith(".View"))
                {
                    var parts = permission.Split('.');
                    if (parts.Length == 3)
                    {
                        var reportName = parts[1];
                        if (!allowedReportNames.Contains(reportName))
                        {
                            allowedReportNames.Add(reportName);
                        }
                    }
                }
            }

            if (!allowedReportNames.Any())
            {
                return Ok(new PaginatedResult<ReportDto>
                {
                    Items = new List<ReportDto>(),
                    Page = page,
                    PageSize = pageSize,
                    Total = 0
                });
            }

            var allReports = await _reportService.GetAllAsync(new FindOptions { PageSize = int.MaxValue });
            var userReports = allReports.Items.Where(r => allowedReportNames.Contains(r.NameEn));

            if (!string.IsNullOrWhiteSpace(search))
            {
                userReports = userReports.Where(r =>
                    r.NameEn.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    r.NameAr.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (r.Description != null && r.Description.Contains(search, StringComparison.OrdinalIgnoreCase)));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                userReports = sortBy.ToLower() switch
                {
                    "nameen" => desc ? userReports.OrderByDescending(r => r.NameEn) : userReports.OrderBy(r => r.NameEn),
                    "namear" => desc ? userReports.OrderByDescending(r => r.NameAr) : userReports.OrderBy(r => r.NameAr),
                    "category" => desc ? userReports.OrderByDescending(r => r.Category) : userReports.OrderBy(r => r.Category),
                    _ => desc ? userReports.OrderByDescending(r => r.NameEn) : userReports.OrderBy(r => r.NameEn)
                };
            }
            else
            {
                userReports = userReports.OrderBy(r => r.NameEn);
            }

            var totalCount = userReports.Count();
            var pagedReports = userReports.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Ok(new PaginatedResult<ReportDto>
            {
                Items = pagedReports,
                Page = page,
                PageSize = pageSize,
                Total = totalCount
            });
        }


        [HttpPost("execute-report")]
        public async Task<ActionResult<PaginatedResult<Dictionary<string, object>>>> ExecuteReport(
                    int reportId,
                    [FromBody] ExecuteReportRequest request)
        {
            var report = await _reportService.GetByIdAsync(reportId);
            if (report == null)
                throw new NotFoundException("Report", reportId.ToString());

            var sql = report.Query;
            var sqlParameters = report.Parameters ?? new List<ReportParameterDto>();
            sqlParameters = sqlParameters.OrderBy(p => p.Sort).ToList();

            var npgsqlParameters = new List<NpgsqlParameter>();

            foreach (var param in sqlParameters)
            {
                object? value = null;

                if (request.Parameters != null && request.Parameters.ContainsKey(param.Name))
                {
                    value = request.Parameters[param.Name];

                    if (value is System.Text.Json.JsonElement jsonElement)
                    {
                        switch (jsonElement.ValueKind)
                        {
                            case System.Text.Json.JsonValueKind.String:
                                value = jsonElement.GetString();
                                break;
                            case System.Text.Json.JsonValueKind.Number:
                                if (jsonElement.TryGetInt32(out int i)) value = i;
                                else if (jsonElement.TryGetDecimal(out decimal d)) value = d;
                                else value = jsonElement.ToString();
                                break;
                            case System.Text.Json.JsonValueKind.True:
                                value = true;
                                break;
                            case System.Text.Json.JsonValueKind.False:
                                value = false;
                                break;
                            case System.Text.Json.JsonValueKind.Null:
                                value = null;
                                break;
                            default:
                                value = jsonElement.ToString();
                                break;
                        }
                    }
                }

                if (value == null && !string.IsNullOrEmpty(param.DefaultValue))
                {
                    value = param.DefaultValue;
                }

                npgsqlParameters.Add(new NpgsqlParameter(param.Name, value ?? DBNull.Value));
            }

            var result = await _postgreExecutor.ExecuteQueryAsync(sql, npgsqlParameters.ToArray(), request.FindOptions);
            return Ok(result);
        }


        [HttpGet("dashboard-cards")]
        public async Task<ActionResult<List<ScalarReportDto>>> ExecuteScalar()
        {
            var dashboardReportsNames = await _reportService.GetDashboardNames();

            var scalarResults = new List<ScalarReportDto>();
            foreach (var name in dashboardReportsNames)
            {
                var report = await _reportService.GetByNameAsync(name);
                if (report == null)
                    throw new NotFoundException("Report", name);
                var sql = report.Query;
                var sqlParameters = report.Parameters;
                sqlParameters = sqlParameters.OrderBy(p => p.Sort).ToList();
                var npgsqlParameters = new List<NpgsqlParameter>();
                foreach (var param in sqlParameters)
                {
                    npgsqlParameters.Add(new NpgsqlParameter(param.Name, param.DefaultValue ?? (object)DBNull.Value));
                }
                var scalarValue = await _postgreExecutor.ExecuteScalarAsync(sql, npgsqlParameters.ToArray());
                scalarResults.Add(new ScalarReportDto
                {
                    Name = report.NameAr ?? "",
                    Value = scalarValue?.ToString() ?? "0"
                });
            }
            return Ok(scalarResults);
        }


        [HttpGet("{reportId}/columns")]
        public async Task<ActionResult<List<ReportColumnDto>>> GetColumnsByReportId(int reportId)
        {
            var columns = await _reportService.GetColumnsByReportIdAsync(reportId);
            return Ok(columns);
        }


        [HttpPost("{reportId}/columns")]
        public async Task<ActionResult<List<ReportColumnDto>>> CreateColumnsForReport(int reportId, List<ReportColumnCreateDto> columns)
        {
            await _reportService.CreateColumnsAsync(reportId, columns);
            return Ok(columns);
        }

        [HttpPut("{reportId}/columns/{columnId}")]
        public async Task<IActionResult> UpdateColumn(int reportId, int columnId, [FromBody] ReportColumnCreateDto dto)
        {
            await _reportService.UpdateColumnAsync(reportId, columnId, dto);
            return NoContent();
        }

        [HttpGet("{reportId}/parameters")]
        public async Task<ActionResult<List<ReportParameterDto>>> GetParametersByReportId(int reportId)
        {
            var parameters = await _reportService.GetParametersByReportIdAsync(reportId);
            return Ok(parameters);
        }

        [HttpPost("{reportId}/parameters")]
        public async Task<ActionResult<List<ReportParameterDto>>> CreateParametersForReport(int reportId, List<ReportParameterCreateDto> parameters)
        {
            await _reportService.CreateParametersAsync(reportId, parameters);
            return Ok(parameters);
        }

        [HttpPut("{reportId}/parameters/{parameterId}")]
        public async Task<IActionResult> UpdateParameter(int reportId, int parameterId, [FromBody] ReportParameterCreateDto dto)
        {
            await _reportService.UpdateParameterAsync(reportId, parameterId, dto);
            return NoContent();
        }

        /// <summary>
        /// Execute a dropdown query to get options for a parameter dropdown
        /// </summary>
        [HttpPost("execute-dropdown-query")]
        public async Task<ActionResult<List<DropdownOption>>> ExecuteDropdownQuery([FromBody] DropdownQueryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Query))
            {
                return BadRequest("Query cannot be empty");
            }

            try
            {
                var results = await _postgreExecutor.ExecuteQueryAsync(request.Query, Array.Empty<NpgsqlParameter>());
                
                var options = new List<DropdownOption>();
                foreach (var row in results.Items)
                {
                    var option = new DropdownOption();
                    
                    // Try to get value (case-insensitive)
                    if (row.TryGetValue("value", out var val) || row.TryGetValue("Value", out val) || row.TryGetValue("VALUE", out val))
                    {
                        option.Value = val?.ToString() ?? "";
                    }
                    else if (row.Count > 0)
                    {
                        option.Value = row.Values.First()?.ToString() ?? "";
                    }
                    
                    // Try to get label (case-insensitive)
                    if (row.TryGetValue("label", out var lbl) || row.TryGetValue("Label", out lbl) || row.TryGetValue("LABEL", out lbl))
                    {
                        option.Label = lbl?.ToString() ?? "";
                    }
                    else if (row.TryGetValue("name", out lbl) || row.TryGetValue("Name", out lbl) || row.TryGetValue("NAME", out lbl))
                    {
                        option.Label = lbl?.ToString() ?? "";
                    }
                    else if (row.Count > 1)
                    {
                        option.Label = row.Values.Skip(1).First()?.ToString() ?? "";
                    }
                    else
                    {
                        option.Label = option.Value;
                    }
                    
                    options.Add(option);
                }
                
                return Ok(options);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to execute dropdown query: {ex.Message}");
            }
        }
    }
}
