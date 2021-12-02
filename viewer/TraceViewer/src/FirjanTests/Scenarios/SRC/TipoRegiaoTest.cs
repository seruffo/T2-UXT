using FirjanTests.Scenarios.Base.CRUD;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.SRC
{
    public class TipoRegiaoTest : Base
    {
        public TipoRegiaoTest()
        {
            Configure("TiposRegioes", "1");
            Body = new
            {
                Descricao = $"TESTE TDD {RandTest}",
            };
        }
    }
}
