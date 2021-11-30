using FirjanTests.Scenarios.Base.CRUD;
using System.Net.Http;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class TipoUnidadeNegocioTest : Base
    {
        public TipoUnidadeNegocioTest()
        {
            Body = new
            {
                Sigla = "TESTETDD",
                Descricao = $"TESTE TDD {RandTest}",
                UnidadeVinculada = new 
                {
                    Id = 'S',
                    Name = "Sim"
                }
            };
            Configure("Gestor/TiposUnidadesNegocios", "24");
        }
    }
}
