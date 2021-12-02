using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Firjan.Integracao.Dynamics.API;

namespace Firjan.Integracao.Dynamics.Tests.Fixtures
{
    public class ApiContext
    {
        public HttpClient Client { get; private set; }
        private TestServer server;
        public ApiContext()
        {
            SetupClient();
        }
        private void SetupClient()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
