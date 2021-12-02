using FirjanTests.Scenarios.Base.CRUD;
using System;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class ContaContabilProdutoTest : Base
    {
        public ContaContabilProdutoTest()
        {
            Body = new
            {
                CodigoEmpresa = "01RJ",
                CodigoConta = "040208",
                ProdutoId = 38693,
                Inicio = DateTime.ParseExact("2024-10-11 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                Fim = DateTime.ParseExact("2024-10-11 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                IsAssistencial = 'S',
                GrupoClassifId = 6590                
            };
            Configure("ContasContabeisProdutos", "01RJ,040208,36,2019-06-11 14:40:52", "ProdutoId");
        }
    }
}
