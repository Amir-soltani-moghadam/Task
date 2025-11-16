using MediatR;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Feature.SalaryCalculation.Requests.Queries
{
    public class GetRengeSalaryCalculationQueryRequest : IRequest<List<SalaryCalculationDto>>
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Datatype { get; set; }
    }
}
