using FirjanTests.Scenarios.Base.Query;
using Xunit;
using Xunit.Priority;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.SGE
{
    public class ModalidadesCursosTest : Base
    {
        public ModalidadesCursosTest() => Configure("ModalidadesCursos", "57");

        [Fact, Priority(2)]
        public new void GetByColigada()
        {
            Get("byColigada/3");
        }
    }
}
