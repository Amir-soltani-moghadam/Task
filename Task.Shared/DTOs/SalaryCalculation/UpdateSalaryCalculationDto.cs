using Task.Shared.DTOs.Comman;

namespace Task.Shared.DTOs.SalaryCalculation
{
    public class UpdateSalaryCalculationDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public string Date { get; set; }
    }
}
