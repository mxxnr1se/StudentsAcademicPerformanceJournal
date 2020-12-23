using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void SwaggerConfigure(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                        Version = "v1",
                        Title = "Student's Academic Performance API",
                        Description = "Api provides work with sap.",
                        Contact = new OpenApiContact
                        {
                                Name = "Sidorov Nikita",
                                Email = string.Empty,
                                Url = new Uri("https://github.com/mxxnr1se"),
                        }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}