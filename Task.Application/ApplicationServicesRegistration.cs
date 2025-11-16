using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Task.Application.Common;

namespace Task.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IDataParser, DataParser>();
        }
    }
}
