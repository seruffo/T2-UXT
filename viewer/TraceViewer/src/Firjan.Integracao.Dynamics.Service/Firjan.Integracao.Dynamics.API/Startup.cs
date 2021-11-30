using AutoMapper;
using Firjan.Integracao.Dynamics.API.Settings;
using Firjan.Integracao.Dynamics.Application.AutoMapperConfigs;
using Firjan.Integracao.Dynamics.Infrastructure.CrossCutting;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Protheus;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.SGE;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using System.Text.Json.Serialization;
using MvcOptions = Firjan.Integracao.Dynamics.API.Settings.MvcOptions;
using Microsoft.Extensions.Hosting;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Contextos;

namespace Firjan.Integracao.Dynamics.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;

            Environment = environment;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.IgnoreNullValues = true;
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services
                .AddApiVersioning(o => {
                    o.ReportApiVersions = true;
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new ApiVersion(1, 0);
                });

            services
                .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

            services
                .AddResponseCompression(options =>
                {
                    options
                    .Providers
                    .Add<GzipCompressionProvider>();
                });

            services
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder
                        .AddConfiguration(Configuration.GetSection("Logging"));

                    loggingBuilder
                        .AddConsole();

                    loggingBuilder
                        .AddDebug();
                });

            services
                .AddOptions();

            services
                .AddApiVersioning();

            MvcOptions
                .AddService(services);

            ServicosAdicionais(services);
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                app
                  .UseDeveloperExceptionPage();

                builder
                  .AddUserSecrets<Startup>();
            }
            else
            {
                app
                 .UseHsts();
            }

            app
              .UseHttpsRedirection();

            MvcOptions
                .Configure(app);

            ConfiguracoesAdicionais(app, env);
        }

        public void AddDbContext<TContext>(IServiceCollection services, string connection) where TContext : DbContext
        {
            services
                .AddDbContext<TContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString(connection), x => x.EnableRetryOnFailure())
                .ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning))
                .EnableSensitiveDataLogging(Environment.IsDevelopment())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));
        }

        protected virtual void ServicosAdicionais(IServiceCollection services)
        {
            //AddDbContext<XMLContext>(services, "Corporativo");

            AddDbContext<CorporativoContext>(services, "Corporativo");

            AddDbContext<SGEContext>(services, "SGE");

            AddDbContext<ProtheusContext>(services, "PROTHEUS");

            services
                .AddLogging();

            services
                .AddAutoMapper(x => x.AddProfile(new ViewModelToDomainMappingProfile()), typeof(ViewModelToDomainMappingProfile));

            Injections
                .RegistrarServicos(services);

            SwaggerApi
                .AddService(services);

            Injections
                .RegistrarSeguranca(services, Configuration);

            if (Environment.IsDevelopment())
            {
                services
                    .AddMvc(opts =>
                    {
                        opts.Filters.Add(new AllowAnonymousFilter());
                    });
            }

       }

        protected virtual void ConfiguracoesAdicionais(IApplicationBuilder app, IWebHostEnvironment env) => SwaggerApi.Configure(app);
    }
}