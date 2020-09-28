using Microsoft.Extensions.DependencyInjection;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using SensorEventsHub.Domain.Services;
using SensorEventsHub.Infrastructure.Context;
using SensorEventsHub.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorEventsHub.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<SensorContext>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<ISensorService, SensorService>();


            return services;
        }
    }
}
