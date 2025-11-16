using System.Data;
using Dapper.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task.Application.Contracts;

namespace Task.Dapper
{
    public static class DapperServicesRegistration
    {
        public static IServiceCollection ConfigureDapperServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TaskConnectionString");

            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

            services.AddScoped<ISalaryCalculationDapperRepository, SalaryCalculationDapperRepository>();

            return services;
        }
    }
}
