using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaxManagementAPI.Core.Configuration;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Core.Services;
using TaxManagementAPI.Database;

namespace TaxManagementAPI.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaxManagementAPI.Core", Version = "v1" });
            });

            ConfigureDatabase(services);
            RegisterServices(services);
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<TaxContext>(opt
                => opt.UseMySQL(Configuration["ApplicationSettings:MySQLConnectionString"]));
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITaxService, TaxService>();

            var appSettings = Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tax Management API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
