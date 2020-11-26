using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TccDev.gRPC.Services;
using TccDev.Mapping;
using Microsoft.Extensions.Configuration;
using TccDev.Domain.Interfaces.Services;
using TccDev.Application.Services;
using TccDev.Domain.Interfaces.Repositories;
using TccDev.Data.Bancos.SQL.Repositories;
using TccDev.Data.Bancos.SQL.EntityFramework.Context;
using TccDev.Data.Bancos.MySQL.Context;
using TccDev.Data.Bancos.MongoDB.Context;

namespace TccDev.gRPC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ApplicationSettings.ConnectionStringSql = Configuration.GetConnectionString("SqlContext");
            ApplicationSettings.ConnectionStringMySql = Configuration.GetConnectionString("MySqlContext");
            ApplicationSettings.ConnectionStringMongoDb = Configuration.GetConnectionString("MongoDbContext");
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SQLContext>();
            services.AddScoped<MySqlContext>();
            services.AddScoped<MongoDbContext>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            

            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ProdutogRPCService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
