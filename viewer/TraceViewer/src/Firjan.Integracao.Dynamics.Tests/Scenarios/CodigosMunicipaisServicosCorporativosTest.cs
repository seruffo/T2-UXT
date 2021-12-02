using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Tests.Fixtures;
using Xunit;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using Xunit.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios
{
    public class CodigosMunicipaisServicosCorporativosTest
    {
        private readonly ApiContext _apiContext;
        public CodigosMunicipaisServicosCorporativosTest()
        {
            _apiContext = new ApiContext();
        }

        [Fact]
        [TestMethod]
        [Timeout(20000)]
        public async Task CodigosMunicipaisServicosCorporativosTest_Post_ValidaData_ReturnsOkResponse()
        {
            var request = new
            {
                Url = "/api/v1/CodigosMunicipaisServicosCorporativos",
                Body = new
                {
                    CodigoMunicipio = "3304557",
                    CodigoServicoMunicipal = "040208",
                    CodigoServicoOficial = "36",
                    Inicio = DateTime.ParseExact("2019-06-11 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",System.Globalization.CultureInfo.InvariantCulture),
                    Fim = DateTime.ParseExact("2019-08-11 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",System.Globalization.CultureInfo.InvariantCulture),
                    SeqMunicipio = 79
                }
            };

            var response = await _apiContext.Client.PostAsync(request.Url, new StringContent(JsonConvert.SerializeObject(request.Body)));

            response.EnsureSuccessStatusCode();

            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [TestMethod]
        [Timeout(20000)]
        public async Task CodigosMunicipaisServicosCorporativosTest_Put_ValidaData_ReturnsOkResponse()
        {
            var request = new
            {
                Url = "/api/v1/CodigosMunicipaisServicosCorporativos",
                Body = new
                {
                    CodigoMunicipio = "3304557",
                    CodigoServicoMunicipal = "040208",
                    CodigoServicoOficial = "36",
                    Inicio = DateTime.ParseExact("2019-06-11 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                    Fim = DateTime.ParseExact("2019-08-11 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                    SeqMunicipio = 79
                }
            };

            var response = await _apiContext.Client.PostAsync(request.Url, new StringContent(JsonConvert.SerializeObject(request.Body)));

            response.EnsureSuccessStatusCode();

            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
