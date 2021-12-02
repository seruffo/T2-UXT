using System;
using System.Net.Http;
using FirjanTests.Scenarios.Base.CRUD;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class CodigoMunicipalServicoCorporativoTest : Base
    {
        public CodigoMunicipalServicoCorporativoTest()
        {
            Body = new
            {
                CodigoServicoOficial = 36,
                CodigoMunicipalId = "3304557",
                CodigoMunicipio = "3304557",
                SeqMunicipio = 79,
                Inicio = DateTime.ParseExact("2020-02-17 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                Fim = DateTime.ParseExact("2024-02-17 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            };
            Configure("CodigosMunicipaisServicosCorporativos", "3304557,36", "CodigoMunicipalId");
        }

        public override void Post() 
        {
            Send(HttpMethod.Post);
            AssertMethod();
            Send(HttpMethod.Put);
            Send(HttpMethod.Delete);
        }
    }
}
