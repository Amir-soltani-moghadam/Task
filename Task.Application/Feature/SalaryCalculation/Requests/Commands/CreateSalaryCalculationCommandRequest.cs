using MediatR;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Feature.SalaryCalculation.Requests.Commands
{
    public class CreateSalaryCalculationCommandRequest : IRequest<SalaryCalculationDto>
    {

        public string Datatype { get; set; }
        public string Data { get; set; }
        public string OverTimeCalculator { get; set; }

    }
}
