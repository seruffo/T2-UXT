using FirjanTests.Scenarios.Base.CRUD;
using System;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class ItemContabilProdutoTest : Base
    {
        public ItemContabilProdutoTest()
        {
            Body = new
            {
                CodigoEmpresa = "003",
                CodigoCentroResponsabilidade = "390070902",
                ProdutoId = 2720,
                Inicio = DateTime.ParseExact("2020-03-11 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                Fim = DateTime.ParseExact("2024-03-11 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
            };

            Configure("ItemsContabeisProdutos", "02RJ,320020300,46097", "ProdutoId");
        }
    }
}
