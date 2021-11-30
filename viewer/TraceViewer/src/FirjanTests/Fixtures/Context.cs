using FirjanTests.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace FirjanTests.Fixtures
{
    public abstract class Context
    {
        public static TestingConfiguration Configuration { get; set; }

        protected Context()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "environment.json");
            string json = File.ReadAllText(path);
            Configuration = JsonConvert.DeserializeObject<TestingConfiguration>(json);
        }

        protected static void SetupEnviroment() 
        {
            Environment
                .SetEnvironmentVariable("Corporativo", Configuration.Corporativo);

            Environment
                .SetEnvironmentVariable("SGE", Configuration.Sge);

            Environment
                .SetEnvironmentVariable("PROTHEUS", Configuration.Protheus);

            Environment
                .SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", Configuration.APNETCORE_ENVIROMENT);

        }
    }
}
