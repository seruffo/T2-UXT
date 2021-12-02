using FirjanTests.Scenarios.Base.CRUD;
using System;
using System.Net.Http;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class TipoEntidadeVinculoTest : Base
    {
        public TipoEntidadeVinculoTest()
        {
            Body = new
            {
                Id = 99,
                Descricao = $"TESTE TDD {RandTest}"
            };

            Configure("Gestor/TiposEntidades", "3");
        }
    }
}