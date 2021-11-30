using Xunit;
using FirjanTests.Scenarios.Base.CRUD;
using Xunit.Priority;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.SRC
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class RegiaoTest : Base
    {
        public RegiaoTest() { 
            Body = new { TipoRegiaoId = 1, Descricao = $"TESTE TDD {RandTest}"};
            Configure("Regioes", "1");
        }        
    }
}
