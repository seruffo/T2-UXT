using FirjanTests.Scenarios.Base.Query;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Protheus
{
    public class FilialTest : Base
    {
        public FilialTest() => Configure("Gestor/Protheus/Filiais", "01RJ0001");
    }
}
