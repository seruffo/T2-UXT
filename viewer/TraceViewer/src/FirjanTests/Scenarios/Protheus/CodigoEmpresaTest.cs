using FirjanTests.Scenarios.Base.Query;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Protheus
{
    public class CodigoEmpresaTest : Base
    {
        public CodigoEmpresaTest() => Configure("Gestor/Protheus/CodigosEmpresas", "02RJ");
    }
}
