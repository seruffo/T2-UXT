using Xunit;
using FirjanTests.Scenarios.Base.CRUD;
using Xunit.Priority;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.SRC
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class BairroTest : Base
    {
        public BairroTest() {

            Body = new
            {
                CodigoMunicipio = 118634,
                CodigoLocalCorreio = 243,
                CodigoBairroCorreio = 148,
                Ativo = 'S',
                Descricao = $"TESTE TDD {RandTest}"
            };

           Configure("Bairros", "1");
        }        
    }
}
