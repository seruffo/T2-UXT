using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Firjan.Integracao.Dynamics.API.Package
{
    public static class EnvironmentExtensions
    {
        public static bool IsTest(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(StandardEnvironment.Test);
        }
        public static bool IsTestExt(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(StandardEnvironment.TestExt);
        }
        public static bool IsDevExt(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(StandardEnvironment.DevExt);
        }
        public static bool IsStagingExt(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(StandardEnvironment.StagingExt);
        }
    }
}
