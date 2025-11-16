using System.Data;
using Dapper.Repositories;
using Task.Application.Contracts;
using Task.Persistence;
using Task.Persistence.Repositories;

namespace Task.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _dbContext;
        private readonly IDbConnection _connection;
        private IDbTransaction? _transaction;
        public UnitOfWork(TaskDbContext dbContext, IDbConnection connection)
        {
            _dbContext = dbContext;
            _connection = connection;
            _connection.Open();
        }
        public ISalaryCalculationRepository SalariesCalculation => new SalaryCalculationRepository(_dbContext);
        public ISalaryCalculationDapperRepository salaryCalculationDapperRepository => new SalaryCalculationDapperRepository(_connection, _transaction);

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task BeginTransactionAsync()
        {
            _transaction = _connection.BeginTransaction();
        }
        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
            _transaction?.Commit();
        }

        public async System.Threading.Tasks.Task RollbackAsync()
        {
            _transaction?.Rollback();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
            _dbContext?.Dispose();
        }
    }
}
