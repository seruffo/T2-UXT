using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Firjan.Integracao.Dynamics.API.Settings
{
	/// <summary>
	/// Configuração do MVC
	/// </summary>
	public static class MvcOptions
    {
        /// <summary>
        /// Nome do Cache Profile utilizado
        /// </summary>
        public const string CacheProfileName = "NonAuthoritativeLongDatabaseDuration";

        private const string CorsPolicyName = "CorsPolicy";

        /// <summary>
        /// Adiciona o serviço de MVC
        /// </summary>
        /// <param name="services">Colleção de serviços</param>
        public static void AddService(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            });

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add(MvcOptions.CacheProfileName, new CacheProfile
                {
                    Duration = (int)TimeSpan.FromMinutes(5).TotalSeconds,
                    Location = ResponseCacheLocation.Any,
                });
            });
        }

        /// <summary>
        /// Configura o MVC
        /// </summary>
        /// <param name="app">Aplicação</param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors(MvcOptions.CorsPolicyName);
            app.UseResponseCompression();
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
