using FirjanTests.Scenarios.Base.CRUD;
using System;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class HierarquiaProdutoTest : Base
    {
        public HierarquiaProdutoTest()
        {
            Body = new 
            {
                Nome = $"TESTE TDD {RandTest}",
                NovaInterface = true,
                TipoServicoId = "C",
                Fim = DateTime.ParseExact("2079-06-06 00:00:02", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) ,
                NumeroOrdem = "10.11.1.6",
                NivelServico = new {
                    Id = 4,
                    Name = "Quarto"
                },
                CodigoTipoEntidadeVinculo = "12",
                IndicadorProduto = new {
                    Id = "S",
                    Name = "Sim"
                },
                GrupoClassificacaoPaiId = 8333,
                GruposClassificacoes = Array.Empty<object>()
            };
            Configure("Gestor/HierarquiasProdutos", "8336");
        }
    }
}
