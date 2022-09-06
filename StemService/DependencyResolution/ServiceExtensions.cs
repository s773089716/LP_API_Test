/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2022-09-05
 *************************************************************************************************/
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StemService.Core.Repositories;
using StemService.Core.Services;
using StemService.Repositories;

namespace StemService.DependencyResolution
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, ILoggerFactory _loggerFactory)
        {
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IStemService, StemService.Services.StemService>();

            return services;
        }
    }
}
