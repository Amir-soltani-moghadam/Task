using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task.Application.Contracts;

namespace Task.UnitOfWork
{
    public static class UnitOfWorkServicesRegistration
    {
        public static IServiceCollection ConfigureUnitOfWorkServices(this IServiceCollection services,
           IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
