using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task.Application.Contracts;
using Task.Persistence.Repositories;

namespace Task.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TaskDbContext>(opstions =>
            {
                opstions.UseSqlServer(configuration.GetConnectionString("TaskConnectionString"));

            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISalaryCalculationRepository, SalaryCalculationRepository>();





            return services;
        }
    }
}
