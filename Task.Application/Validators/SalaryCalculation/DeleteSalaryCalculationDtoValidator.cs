using FluentValidation;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Validators.SalaryCalculation
{
    public class DeleteSalaryCalculationDtoValidator : AbstractValidator<DeleteSalaryCalculationDto>
    {
        public DeleteSalaryCalculationDtoValidator()
        {

        }
    }
}
