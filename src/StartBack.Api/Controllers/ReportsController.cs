using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StartBack.Application.Services;
using StartBack.Application.DTOs.Report;
using StartBack.Application.DTOs.ReportColumn;
using StartBack.Domain.Exceptions;
using StartBack.Domain.Helpers;
using StartBack.Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using StartBack.Application.Abstractions;

namespace StartBack.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/reports")]
    //[Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;
        private readonly OracleSqlExecutor _oracleExecutor;
        private readonly IPermissionService _permissionService;
        private readonly IUserService _userService;


        public ReportsController(ReportService reportService, OracleSqlExecutor oracleExecutor, IPermissionService permissionService, IUserService userService)
        {
            _reportService = reportService;
            _oracleExecutor = oracleExecutor;
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
            //return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
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
            // Get permissions directly from JWT token claims
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

            // Extract report names from user's permissions that follow pattern Reports.{nameEn}.View
            var allowedReportNames = new List<string>();
            foreach (var permission in permissionClaims)
            {
                if (permission.StartsWith("Reports.") && permission.EndsWith(".View"))
                {
                    var parts = permission.Split('.');
                    if (parts.Length == 3)
                    {
                        var reportName = parts[1]; // This is the nameEn of the report
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

            // Get all reports and filter by the ones user has permission for
            var allReports = await _reportService.GetAllAsync(new FindOptions { PageSize = int.MaxValue });
            var userReports = allReports.Items.Where(r => allowedReportNames.Contains(r.NameEn));

            // Apply search filter if provided
            if (!string.IsNullOrWhiteSpace(search))
            {
                userReports = userReports.Where(r =>
                    r.NameEn.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    r.NameAr.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (r.Description != null && r.Description.Contains(search, StringComparison.OrdinalIgnoreCase)));
            }

            // Apply sorting
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

        //[HttpPost("execute-report")]
        //public async Task<ActionResult<PaginatedResult<ReportDto>>> ExecuteReport(int reportId)
        //{
        //    var report = await _reportService.GetByIdAsync(reportId);
        //    if (report == null)
        //        throw new NotFoundException("Report", report.Name);
        //    var sql = report.Query;
        //    var sqlParameters = report.Parameters;
        //    sqlParameters = sqlParameters.OrderBy(p => p.Sort).ToList(); // Ensure parameters are sorted by name
        //    var oracleParameters = new List<OracleParameter>();
        //    int index = 0;

        //    foreach (var param in sqlParameters)
        //    {
        //        //if (param.DataType.ToLower() == "number")


        //        // Ensure the sort of oracleParameters and add them in the same order as in the query  
        //        oracleParameters.Add(new OracleParameter(param.Name, param.DataType) { Value = param.DefaultValue });
        //        index++;
        //    }
        //    var resultTable = await _oracleExecutor.ExecuteQueryAsync(sql, oracleParameters.ToArray());
        //    return Ok(resultTable);
        //}

        [HttpPost("execute-report")]
        public async Task<ActionResult<PaginatedResult<Dictionary<string, object>>>> ExecuteReport(
                    int reportId,
                    [FromBody] FindOptions? findOptions = null)
        {
            var report = await _reportService.GetByIdAsync(reportId);
            if (report == null)
                throw new NotFoundException("Report", report.NameEn);

            var sql = report.Query;
            var sqlParameters = report.Parameters;
            sqlParameters = sqlParameters.OrderBy(p => p.Sort).ToList();

            var oracleParameters = new List<OracleParameter>();
            int index = 0;

            foreach (var param in sqlParameters)
            {
                oracleParameters.Add(new OracleParameter(param.Name, param.DataType) { Value = param.DefaultValue });
                index++;
            }

            var result = await _oracleExecutor.ExecuteQueryAsync(sql, oracleParameters.ToArray(), findOptions);
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
                sqlParameters = sqlParameters.OrderBy(p => p.Sort).ToList(); // Ensure parameters are sorted by name
                var oracleParameters = new List<OracleParameter>();
                foreach (var param in sqlParameters)
                {
                    oracleParameters.Add(new OracleParameter(param.Name, param.DataType) { Value = param.DefaultValue });
                }
                var scalarValue = await _oracleExecutor.ExecuteScalarAsync(sql, oracleParameters.ToArray());
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











    }
}

