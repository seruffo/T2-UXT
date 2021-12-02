using FirjanTests.Scenarios.Base.CRUD;
using System;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class ClasseValorProdutoTest : Base
    {
        public ClasseValorProdutoTest()
        {
            Body = new
            {
                CodigoEmpresa = "003",
                CodigoCentroResponsabilidade = "3900709",
                ProdutoId = 2720,
                Inicio = DateTime.ParseExact("2024-03-06 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                Fim = DateTime.ParseExact("2028-03-06 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
            };
            Configure("ClassesValoresProdutos", "04RJ,DOTRE0059,45547", "ProdutoId");
        }
    }
}
