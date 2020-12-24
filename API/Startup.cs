using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Configurations;
using API.Configurations.Dependencies;
using API.Configurations.Logger;
using API.Configurations.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.DALDependenciesResolver(Configuration);
            services.BLLDependenciesResolver();
            services.AddSingleton(AutoMapperConfiguration.CreateMapper());
            services.AddSingleton<ILog, MyLogger>();
            
            services.SwaggerConfigure();
            
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILog logger)
        {
            app.ConfigureExceptionHandler(logger);
            
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            
            app.UseSwagger(c => {c.SerializeAsV2 = true;});
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student's Academic Performance API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}