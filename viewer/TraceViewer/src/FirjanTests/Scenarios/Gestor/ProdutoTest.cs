using FirjanTests.Scenarios.Base.CRUD;
using System;
using System.Net.Http;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class ProdutoTest : Base
    {
        public ProdutoTest()
        {
            Body = new
            {
                Inicio = DateTime.ParseExact("2020-02-17 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                Fim = DateTime.ParseExact("2024-02-17 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                Divulgado = new { Id = "S", Name = "Sim" },
                DivulgadoSite = new { Id = "N", Name = "Não" },
                NivelServicoId = 1,
                TabelaServicoId = 6,
                TipoEntidadeVinculoId = "44",
                TipoServicoId = "S",
                Dedutivel = new { Id = "N", Name = "Não" },
                AreaId = "63",
                ServicoOficialId = 841,
                PlataformaId = 35,
                TUSSId = 375,
                ClassificacaoServicoId = 10,
                LinhaServicoId = 9,
                ExigeCPF = true,
                Descricao = $"TESTE TDD {RandTest}",
                NomeResumido = $"TESTE TDD {RandTest}",
                Categoria = new { Id = 'M', Name = "Material" },
                Especialidade = new { Id = 'S', Name = "Sim" },
                ValeCultura = new { Id = 'S', Name = "Sim" },
                Atendimento = new { Id = 'S', Name = "Sim" },
                NumeroAgente = 1596,
                Validade = DateTime.ParseExact("2020-02-17 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture)
            };

            Configure("Gestor/Produtos", "31");
        }
    }
}