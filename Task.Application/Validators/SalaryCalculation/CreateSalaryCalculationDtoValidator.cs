using FluentValidation;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Validators.SalaryCalculation
{
    public class CreateSalaryCalculationDtoValidator : AbstractValidator<CreateSalaryCalculationDto>
    {
        public CreateSalaryCalculationDtoValidator()
        {

        }
    }
}
