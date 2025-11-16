using Task.Application.Contracts;
using Task.Domain;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Persistence.Repositories
{
    public class SalaryCalculationRepository : GenericRepository<SalariesCalculation>, ISalaryCalculationRepository
    {
        private readonly TaskDbContext _DbContext;
        public SalaryCalculationRepository(TaskDbContext dbcontext) : base(dbcontext)
        {
            _DbContext = dbcontext;
        }

        public Task<IReadOnlyList<SalaryCalculationDto>> GetRangeSalariesCalculationAsync(string fDate, string lDate)
        {
            throw new NotImplementedException();
        }
    }
}
