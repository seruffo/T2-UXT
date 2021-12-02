using FirjanTests.Scenarios.Base.CRUD;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class CodigoMunicipalTest : Base
    {
        public CodigoMunicipalTest()
        {
            Body = new
            {
                Id = "041803",
                CoodigoMunicipio = "3304557",
                Descricao = $"TESTE TDD {RandTest}",
                MunicipioId = 79,
                AliqISS = 0.5,
                CNAE = "8599698"
            };
            Configure("Gestor/CodigosMunicipais", "010101");
        }
    }
}
