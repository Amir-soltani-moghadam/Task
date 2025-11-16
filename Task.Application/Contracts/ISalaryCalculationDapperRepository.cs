using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Contracts
{
    public interface ISalaryCalculationDapperRepository
    {
        Task<IReadOnlyList<SalaryCalculationDto>> GetRangeSalariesCalculationAsync(string fDate, string lDate);
        Task<SalaryCalculationDto> GetSalaryCalculationAsync(int id);

    }
}
