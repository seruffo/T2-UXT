using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Firjan.Integracao.Dynamics.API.Settings
{
    /// <summary>
    /// Configurações de Startup para o Swagger
    /// </summary>
    public static class SwaggerApi
    {
        /// <summary>
        /// Adiciona a configuração de serviço do Swagger
        /// </summary>
        /// <param name="services">Coleção de serviços</param>
        public static void AddService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Firjan API",
                    Description = "webAPI da Firjan em ASP.NET Core 2.2",
                    TermsOfService = new Uri("https://Firjan.com.br/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "DISIS",
                        Email = "fpaugusto@firjan.com.br",
                        Url = new Uri("https://Firjan.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Firjan",
                        Url = new Uri("https://Firjan.com.br")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.CustomSchemaIds(i => i.FullName);
            });

            services.ConfigureSwaggerGen(swaggerGen =>
            {
                swaggerGen.OperationFilter<ApiVersionFilter>();
            });
        }

        /// <summary>
        /// Configura o Swagger
        /// </summary>
        /// <param name="app">Aplicação</param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Firjan Segurança API v1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}