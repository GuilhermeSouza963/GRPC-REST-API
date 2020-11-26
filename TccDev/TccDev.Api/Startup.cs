using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using TccDev.Hosting;
using TccDev.Mapping;

namespace TccDev.Api
{
    public class Startup
    {
        private readonly Container container;
        public Startup(IConfiguration configuration)
        {
            container = DependenceInjectionConfig.CreateInstance(Lifestyle.Transient);
            Configuration = configuration;
            ApplicationSettings.ConnectionStringSql = Configuration.GetConnectionString("SqlContext");
            ApplicationSettings.ConnectionStringMySql = Configuration.GetConnectionString("MySqlContext");
            ApplicationSettings.ConnectionStringMongoDb = Configuration.GetConnectionString("MongoDbContext");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DependenceInjectionConfig.IntegrateSimpleInjector(services);
            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeContainer(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);

            DependenceInjectionConfig.Config();
            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);
        }
    }
}
