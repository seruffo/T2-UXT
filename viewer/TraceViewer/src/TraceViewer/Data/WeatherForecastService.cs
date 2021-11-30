using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace TraceViewer.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<Trace[]> GetForecastAsync(DateTime startDate, string type)
        {
            RestClient client = null;

            var request = new RestRequest(Method.POST);

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new { login = "TFirjan12ab", accesskey = "DISISRules" });

            client = new RestClient("http://localhost:33224/IntegracaoDynamics/api/Logins");

            RestResponse response = (RestResponse)client.Execute(request);

            Token token =  JsonSerializer.Deserialize<Token>(response.Content);

            client = new RestClient("http://localhost:33224/IntegracaoDynamics/api/Trace/V1/GetAll/id/asc/50/0");

            client.AddDefaultHeader("authorization", "Bearer " + token.accessToken);

            request = new RestRequest(Method.GET);

            response = (RestResponse)client.Execute(request);

            RequestResult result = JsonSerializer.Deserialize<RequestResult>(response.Content);

            IList<Trace> traces = JsonSerializer.Deserialize<IList<Trace>>(Convert.ToString(result.data));

            if (type != "All")
            {
                traces = traces.Where(r => r.type == type).ToList();
            }

            return Task.FromResult(traces.ToArray());
        }
    }
}
