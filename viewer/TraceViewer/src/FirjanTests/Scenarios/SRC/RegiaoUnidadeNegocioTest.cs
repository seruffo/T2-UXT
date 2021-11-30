using FirjanTests.Scenarios.Base.CRUD;
using System;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.SRC
{
    public class RegiaoUnidadeNegocioTest : Base
    {
        public RegiaoUnidadeNegocioTest()
        {
            Configure("RegioesUnidadesNegocios", null, "RegiaoId", "GetByPrimaryKey", "3,208,824");
            Body = new
            {
                RegiaoId = 25,
                TipoRegiaoId = 4,
                UnidadeNegocioId = 292,
                Inicio = DateTime.ParseExact("2020-03-06 14:40:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                Fim = DateTime.ParseExact("2024-03-06 14:40:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
            };
        }
    }
}
