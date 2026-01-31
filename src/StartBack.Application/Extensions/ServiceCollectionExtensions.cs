using Microsoft.Extensions.DependencyInjection;
using StartBack.Application.Services;

namespace StartBack.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var applicationAssemply = typeof(ServiceCollectionExtensions).Assembly;
            services.AddAutoMapper(applicationAssemply);

            services.AddScoped<ReportService>();



        }

    }
}
