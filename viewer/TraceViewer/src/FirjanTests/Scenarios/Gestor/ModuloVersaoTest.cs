using FirjanTests.Scenarios.Base.CRUD;
using System;
using System.Dynamic;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class ModuloVersaoTest : Base
    {
        public ModuloVersaoTest()
        {
            Body = new ExpandoObject();
            {
                Body.Codigo = "86331";
                Body.NumeroVersao = "1";
                Body.QtdHoras = 20;
                Body.CodigoInstrucao = "4";
                Body.Instrucao = new
                {
                    Codigo = "4",
                    Descricao = "Fundamental - 2o segmento incompleto"
                };
                Body.TipoModalidadeId = 4;
                Body.QtdHorasEstagio = 0;
                Body.RefazCurso = new
                {
                    Id = "S",
                    Name = "Sim"
                };
                Body.ContemDisciplina = new
                {
                    Id = "S",
                    Name = "Sim"
                };
                Body.GeraNumeroCertificado = new
                {
                    Id = "S",
                    Name = "Sim"
                };
                Body.ProdutoId = 0;
                Body.Nome = $"TESTE TDD {RandTest}";
                Body.NomeResumido = $"TESTE TDD {RandTest}";
                Body.Inicio = DateTime.ParseExact("2020-02-17 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                Body.Fim = DateTime.ParseExact("2024-02-17 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                Body.PortifolioEducacaoId = 246;
                Body.FlagProcessoSeletivo = false;
                Body.CustoSistema = new
                {
                    Id = "N",
                    Name = "Não"
                };
                Body.TipoModulo = new
                {
                    Id = 'P',
                    Name = "Presencial"
                };
                Body.IdadeMinimaEducacao = 0;
                Body.IdadeMaximaEducacao = 0;                
            };

            Configure("ModulosVersoes", "27421,1", "Codigo");
        }

        public override void Post()
        {
            var ProdutoTest = new ProdutoTest();

            ProdutoTest.SendPost();

            Body.ProdutoId = ProdutoTest.Body.id.ToObject<int>();

            base.Post();

            ProdutoTest.SendDelete();
        }
    }
}
