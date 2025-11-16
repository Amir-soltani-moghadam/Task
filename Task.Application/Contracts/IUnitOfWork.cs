
namespace Task.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {

        ISalaryCalculationRepository SalariesCalculation { get; }
        ISalaryCalculationDapperRepository salaryCalculationDapperRepository { get; }

        Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task BeginTransactionAsync();
        System.Threading.Tasks.Task CommitAsync();
        System.Threading.Tasks.Task RollbackAsync();
    }
}
