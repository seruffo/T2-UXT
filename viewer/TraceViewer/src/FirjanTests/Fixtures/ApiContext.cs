using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Firjan.Integracao.Dynamics.API;
using System.IO;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http.Headers;
using FirjanTests.Fixtures;

namespace Firjan.Integracao.Dynamics.Tests.Fixtures
{
    public class ApiContext : Context
    {
        private static ApiContext instance = null;

        private ApiContext() { }

        public static ApiContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiContext();
                    SetupClient();
                }
                return instance;
            }
        }

        public HttpClient Client { get; set; }

        public bool Isdesenv => Configuration.IsDesenv;

        public string Login => Configuration.Login;

        public string AccesKey => Configuration.AccessKey;

        public string UrlToken => Configuration.UrlToken;

        private static void ClientConfig(IWebHostBuilder builder)
        {
            if (instance.Isdesenv)
            {
                builder
                    .UseStartup<Startup>();

               instance.Client = new TestServer(builder).CreateClient();

                instance.Client
                     .BaseAddress = new Uri(string.Concat(Configuration.Host, "/", Configuration.Path));
            }
            else
            {
                var host = @Configuration.Host;
                instance.Client = new HttpClient()
                {
                    BaseAddress = new Uri(string.Concat(Configuration.Host, "/", Configuration.Path))
                };
            }

            instance.Client
                .DefaultRequestHeaders
                .Accept.Clear();

            instance.Client
                .DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static void SetupClient()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables(); 

            var webBuilder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(builder.Build())
                .UseEnvironment(Configuration.APNETCORE_ENVIROMENT);

            SetupEnviroment();

            ClientConfig(webBuilder);
        }
    }
}
