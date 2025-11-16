using MediatR;
using Task.Shared.DTOs.SalaryCalculation;
namespace Task.Application.Feature.SalaryCalculation.Requests.Queries
{
    public class GetSalaryCalculationQueryRequest : IRequest<SalaryCalculationDto>
    {
        public int Id { get; set; }
        public string Datatype { get; set; }
    }
}
