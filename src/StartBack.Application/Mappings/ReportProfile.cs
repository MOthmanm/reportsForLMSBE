using AutoMapper;
using StartBack.Application.DTOs.Report;
using StartBack.Application.DTOs.ReportColumn;
using StartBack.Application.DTOs.ReportParameter;
using StartBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartBack.Application.Mappings
{
    class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportParameter, ReportParameterDto>();
            CreateMap<ReportColumn, ReportColumnDto>();

            CreateMap<Report, ReportDto>()
                .ForMember(dest => dest.Columns, opt => opt.MapFrom(src => src.Columns))
                .ForMember(dest => dest.Parameters, opt => opt.MapFrom(src => src.Parameters))
                ;
            CreateMap<ReportCreateDto, Report>();
            CreateMap<ReportUpdateDto, Report>();

            CreateMap<ReportColumn, ReportColumnDto>().ReverseMap();
            CreateMap<ReportColumnCreateDto, ReportColumn>();
            CreateMap<ReportColumnCreateDto, ReportColumnDto>().ReverseMap();





        }
    }
}
