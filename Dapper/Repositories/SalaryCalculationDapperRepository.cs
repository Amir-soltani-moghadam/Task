using System.Data;
using Task.Application.Contracts;
using Task.Shared.DTOs.SalaryCalculation;

namespace Dapper.Repositories
{
    public class SalaryCalculationDapperRepository : ISalaryCalculationDapperRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction? _transaction;

        public SalaryCalculationDapperRepository(IDbConnection connection, IDbTransaction? transaction = null)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IReadOnlyList<SalaryCalculationDto>> GetRangeSalariesCalculationAsync(string fDate, string lDate)
        {
            string sql = "SELECT * FROM SalariesCalculations WHERE Date BETWEEN @fDate AND @lDate";
            return (await _connection.QueryAsync<SalaryCalculationDto>(sql, new { fDate, lDate }, _transaction)).AsList();
        }

        public async Task<SalaryCalculationDto> GetSalaryCalculationAsync(int id)
        {
            string sql = "SELECT * FROM SalariesCalculations WHERE Id = @id";
            return await _connection.QueryFirstOrDefaultAsync<SalaryCalculationDto>(sql, new { id }, _transaction);
        }
    }
}
