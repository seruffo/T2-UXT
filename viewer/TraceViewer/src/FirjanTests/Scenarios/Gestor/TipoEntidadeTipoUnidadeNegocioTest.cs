using System;
using FirjanTests.Scenarios.Base.CRUD;


namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class TipoEntidadeTipoUnidadeNegocioTest : Base
    {
        public TipoEntidadeTipoUnidadeNegocioTest()
        {
            Body = new
            {
                Id = 99,
                TipoUnidadeNegocioId = 24,
                TipoEntidadeVinculoId = "55"
            };
            Configure("Gestor/TiposEntidadesTiposUnidadesNegocios", "24");
        }
    }
}
