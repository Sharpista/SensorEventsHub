using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using SensorEventsHub.Infrastructure.Context;
using SensorEventsHub.Infrastructure.Repositorios;
using SensorEventsHub.API.Data;

namespace SensorEventsHub.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<SensorContext>();
            services.AddScoped<ISensorRepository, SensorRepository>();
          //  services.AddScoped<ISensorService, SensorService>();

            var connectionString = Configuration.GetConnectionString("SensorEventsHubDB");
            
            services.AddDbContext<SensorContext>(option => option
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString));

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<SensorEventsHubAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SensorEventsHubAPIContext")));


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
