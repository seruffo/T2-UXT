using FirjanTests.Scenarios.Base.CRUD;
using System;
using System.Dynamic;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class SaudesTest : Base
    {
        public SaudesTest() 
        {
            Body = new ExpandoObject();
            {
                Body.ProdutoId = 36;
                Body.Produto = new
                {
                    Id = 36,
                    NomeResumido = $"TESTE TDD {RandTest}",
                    Dedutivel = new
                    {
                        Id = 'N',
                        Name = "Não"
                    },
                    NumeroAgente = "1596",
                    ExigeCPF = true
                };
                Body.TipoServicoSaude = new 
                {
                    Id = 'C',
                    Name = "Consulta"
                };
                Body.Exame = new 
                {
                    Id = 'N',
                    Name = "Não"
                };
                Body.TipoClassificacao = new 
                {
                    Id = 'M',
                    Name = "Médico"
                };
                Body.GrupoClassificacaoId = 4957;
                Body.CodigoServico = "40118";
                Body.Estado = new 
                {
                    Id = 'A',
                    Name = "Aprovado"
                };
                Body.TipoOrigemServico = new
                {
                    Id = '4',
                    Name = "Mudança de Função"
                };
                Body.TipoResultado = new 
                { 
                    Id = 1, 
                    Name = "Limites" 
                };
                Body.TipoServicoOdontologico = new
                {
                    Id = 'I',
                    Name = "Inicial"
                };
                Body.QtdDentesEnvolvidos = new
                {
                    Id = 0,
                    Name = "Nenhum"
                };
                Body.MarcarHora = new 
                { 
                    Id = 'S', 
                    Name = "Sim" 
                };
                Body.OrigemSaude = new
                {
                    Id = 'B',
                    Name = "Ambos"
                };
                Body.Quantificavel = new 
                { 
                    Id = 'S', 
                    Name = "Sim" 
                };
                Body.TempoAtendimento = DateTime.ParseExact("1900-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                Body.AgendaTeleatendimento = true;
                Body.Fim = DateTime.ParseExact("2079-06-06 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }

            Configure("Gestor/Saudes", "21912"); 
        }     
    }
}
