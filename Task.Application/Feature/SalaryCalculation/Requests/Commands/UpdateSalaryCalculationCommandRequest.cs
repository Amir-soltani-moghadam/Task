using MediatR;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Feature.SalaryCalculation.Requests.Commands
{
    public class UpdateSalaryCalculationCommandRequest : IRequest<SalaryCalculationDto>
    {
        public int Id { get; set; }
        public string Datatype { get; set; }
        public string Data { get; set; }
        public string OverTimeCalculator { get; set; }
    }
}
