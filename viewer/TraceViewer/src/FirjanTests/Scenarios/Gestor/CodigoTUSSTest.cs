using FirjanTests.Scenarios.Base.CRUD;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class CodigoTUSSTest : Base
    {
        public CodigoTUSSTest()
        {
            Body = new 
            {
                Codigo = "9999999999",
                Descricao = $"DESCRIÇÂO TDD {RandTest}"
            };
            Configure("Gestor/TUSS", "2");
        }
    }
}
