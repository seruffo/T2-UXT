using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Firjan.Integracao.Dynamics.API.Settings
{
    public class ApiVersionFilter : IOperationFilter
    {
        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            foreach (var parameter in operation.Parameters)
            {
                if (parameter.Name.Equals("version", System.StringComparison.OrdinalIgnoreCase))
                {
                    parameter.Description = "Versão";
                    parameter.Extensions.Add("default", new OpenApiString("V1"));
                }
            }            
        }
    }
}