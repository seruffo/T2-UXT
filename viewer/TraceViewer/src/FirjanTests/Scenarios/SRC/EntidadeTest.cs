using Xunit;
using FirjanTests.Scenarios.Base.CRUD;
using Xunit.Priority;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.SRC
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class EntidadeTest : Base
    {
        public EntidadeTest() { 
            Body = new { Id = 8, Descricao = $"TESTE TDD {RandTest}"};
            Configure("SRC/Entidades", "1");
        }        
    }
}
