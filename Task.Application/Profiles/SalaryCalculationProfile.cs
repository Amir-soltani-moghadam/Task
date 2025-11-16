using AutoMapper;
using Task.Domain;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Profiles
{
    public class SalaryCalculationProfile : Profile
    {
        public SalaryCalculationProfile()
        {
            CreateMap<SalariesCalculation, SalaryCalculationDto>().ReverseMap();
            CreateMap<SalariesCalculation, UpdateSalaryCalculationDto>().ReverseMap();
            CreateMap<SalariesCalculation, CreateSalaryCalculationDto>().ReverseMap();
        }
    }
}
