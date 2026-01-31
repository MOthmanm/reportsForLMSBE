using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartBack.Domain.Interfaces;
using StartBack.Application.DTOs.Report;
using StartBack.Application.DTOs.ReportColumn;
using StartBack.Domain.Entities;
using StartBack.Domain.Exceptions;
using StartBack.Domain.Helpers;
using System.Data;
using System.Xml.Linq;

namespace StartBack.Application.Services
{
    public class ReportService
    {
        private readonly IGenericRepository<Report> _reportRepository;
        private readonly IGenericRepository<Permission> _permissionRepository;

        private readonly IGenericRepository<ReportColumn> _reportColumnRepository;
        private readonly IMapper _mapper;

        public ReportService(IGenericRepository<Report> reportRepository, IMapper mapper, IGenericRepository<ReportColumn> reportColumnRepository, IGenericRepository<Permission> permissionRepository)
        {
            _reportRepository = reportRepository;

            _mapper = mapper;
            _reportColumnRepository = reportColumnRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<PaginatedResult<ReportDto>> GetAllAsync(FindOptions options)
        {
            var reports = await _reportRepository.GetAllAsync(options);
            var activeReports = reports.Items.Where(r => r.Active && !r.Hide);
            return new PaginatedResult<ReportDto>
            {
                Items = _mapper.Map<IEnumerable<ReportDto>>(activeReports),
                Page = reports.Page,
                PageSize = reports.PageSize,
                Total = reports.Total,

            };
        }

        public async Task<ReportDto> GetByIdAsync(int id)
        {
            var report = await _reportRepository.GetByIdAsync(id, q => q.Include(t => t.Parameters), q => q.Include(t => t.Columns));
            if (report == null)
                throw new NotFoundException("Report", id.ToString());
            return _mapper.Map<ReportDto>(report);
        }

        //public async Task<PaginatedResult<ReportDto>> GetByRoleAsync(FindOptions options)
        //{
        //    var reports = await _reportRepository.GetAllAsync(options);
        //    var activeReports = reports.Items.Where(r => r.Active && !r.Hide && r.ForRole);
        //    return new PaginatedResult<ReportDto>
        //    {
        //        Items = _mapper.Map<IEnumerable<ReportDto>>(activeReports),
        //        Page = reports.Page,
        //        PageSize = reports.PageSize,
        //        Total = reports.Total,
        //    };
        //}

        public async Task<ReportDto> GetByNameAsync(string name)
        {
            var reports = await _reportRepository.FindAsync(r => r.NameEn == name, q => q.Include(t => t.Parameters), q => q.Include(t => t.Columns));
            var report = reports.FirstOrDefault();
            if (report == null)
                throw new NotFoundException("Report", name);
            return _mapper.Map<ReportDto>(report);
        }

        public async Task<List<string>> GetDashboardNames()
        {
            var reports = await _reportRepository.FindAsync(r => r.Category == "Dashboard" && r.Active);
            return reports.Select(r => r.NameEn).ToList();
        }



        public async Task<ReportDto> CreateAsync(ReportCreateDto dto)
        {


            var report = _mapper.Map<Report>(dto);

            var existingReport = await _reportRepository.FindAsync(r => r.NameEn == dto.NameEn);
            if (existingReport.Any())
                throw new DuplicateException("Report", "NameEn", dto.NameEn);

            else
            {
                await _reportRepository.AddAsync(report);
            }

            //var permissions = new List<Permission> ();
            //permissions.Add(new Permission { Code = report.NameEn+".View", Name = "رؤية "+report.NameAr });
            //permissions.Add(new Permission { Code = report.NameEn+".Read", Name = "قراءة "+report.NameAr });


            await _permissionRepository.AddAsync(new Permission { Code = "Reports." + report.NameEn + ".View", Name = "رؤية " + report.NameAr });





            return _mapper.Map<ReportDto>(report);
        }

        public async Task UpdateAsync(int id, ReportUpdateDto dto)
        {
            var report = await _reportRepository.GetByIdAsync(id);
            if (report == null)
                throw new NotFoundException("Report", id.ToString());
            _mapper.Map(dto, report);
            await _reportRepository.Update(report);
        }

        public async Task DeleteAsync(int id)
        {
            var report = await _reportRepository.GetByIdAsync(id);
            if (report == null)
                throw new NotFoundException("Report", id.ToString());
            await _reportRepository.Delete(report);
        }


        public async Task<List<ReportColumnDto>> GetColumnsByReportIdAsync(int reportId)
        {
            var report = await _reportRepository.GetByIdAsync(reportId, q => q.Include(t => t.Columns));
            if (report == null)
                throw new NotFoundException("Report", reportId.ToString());

            return _mapper.Map<List<ReportColumnDto>>(report.Columns);
        }

        public async Task<ReportColumnDto> GetColumnByIdAsync(int id)
        {
            var column = await _reportColumnRepository.GetByIdAsync(id);
            if (column == null)
                throw new NotFoundException("ReportColumn", id.ToString());
            return _mapper.Map<ReportColumnDto>(column);

        }
        public async Task<List<ReportColumnDto>> CreateColumnsAsync(int reportId, List<ReportColumnCreateDto> reportColumns)
        {
            var report = await _reportRepository.GetByIdAsync(reportId);
            if (report == null)
                throw new NotFoundException("Report", reportId.ToString());

            foreach (var columnDto in reportColumns)
            {
                var column = _mapper.Map<ReportColumn>(columnDto);
                column.ReportId = reportId;
                await _reportColumnRepository.AddAsync(column);
            }


            var columns = _mapper.Map<List<ReportColumnDto>>(reportColumns);
            return columns;

        }

        public async Task<ReportColumnDto> UpdateColumnAsync(int reportId, int columnId, ReportColumnCreateDto dto)
        {
            var report = await _reportRepository.GetByIdAsync(reportId);
            if (report == null)
                throw new NotFoundException("Report", reportId.ToString());
            var column = await _reportColumnRepository.GetByIdAsync(columnId);
            if (column == null)
                throw new NotFoundException("ReportColumn", columnId.ToString());
            _mapper.Map(dto, column);
            await _reportColumnRepository.Update(column);
            return _mapper.Map<ReportColumnDto>(column);
        }


    }
}
