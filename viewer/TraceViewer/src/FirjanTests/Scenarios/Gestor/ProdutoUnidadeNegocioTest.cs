using FirjanTests.Scenarios.Base.CRUD;
using System;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class ProdutoUnidadeNegocioTest : Base
    {
        public ProdutoUnidadeNegocioTest()
        {
            Body = new
            {
                Inicio = DateTime.ParseExact("2020-03-06 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                Fim = DateTime.ParseExact("2024-03-06 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                ProdutoId = 24931,
                UnidadeNegocioId = 287,
                ExecutaServicoOferecido = 'S'
            };           
            
            Configure("ProdutosUnidadesNegocios", "342276");
        }
    }
}