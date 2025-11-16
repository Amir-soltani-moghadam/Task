using FluentValidation;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Validators.SalaryCalculation
{
    public class UpdateSalaryCalculationDtoValidator : AbstractValidator<DeleteSalaryCalculationDto>
    {
        public UpdateSalaryCalculationDtoValidator()
        {

        }
    }
}
