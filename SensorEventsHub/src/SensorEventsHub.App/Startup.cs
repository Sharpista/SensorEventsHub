using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SensorEventsHub.App.Config;
using SensorEventsHub.App.Data;
using SensorEventsHub.App.Hubs;
using SensorEventsHub.Infrastructure.Context;

namespace SensorEventsHub.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.ResolverDependencias();
           services.AddSingleton<HttpClient>();
            services.AddAutoMapper(typeof(Startup));
     

            services.AddDbContext<SensorContext>(option => option
            .UseMySql(Configuration.GetConnectionString("SensorEventsHubDB")));
            services.AddResponseCompression();

            services.AddSignalR();
           

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseResponseCompression();
            app.UseStaticFiles();
         
            app.UseRouting();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapHub<EventoHub>("/EventoHub");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
