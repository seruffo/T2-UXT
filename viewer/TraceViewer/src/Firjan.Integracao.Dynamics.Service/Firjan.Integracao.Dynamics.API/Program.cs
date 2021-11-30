using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Firjan.Integracao.Dynamics.API
{
    public class Program
    {
        protected Program() { }

        public static void Main(string[] args)
        {
            var hosts = CreateWebHostBuilder(args).Build();

            hosts.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseApplicationInsights();
    }
}
