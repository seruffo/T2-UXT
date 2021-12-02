using FirjanTests.Scenarios.Base.CRUD;

namespace Firjan.Integracao.Dynamics.Tests.Scenarios.Gestor
{
    public class TipoFichaTest :  Base
    {
        public TipoFichaTest()
        {
            Body = new
            {
                HistFisioVac = new {
                    Id = 'N',
                    Name = "Não"
                 },
                HistFam = new {
                    Id = 'N',
                    Name = "Não"
                },
                HppInter = new {
                    Id = 'N',
                    Name = "Não"
                },
                HppDoencas = new {
                    Id = 'N',
                    Name = "Não"
                },
                Habitos = new {
                    Id = 'N',
                    Name = "Não"
                },
                CondHab = new {
                    Id = 'N',
                    Name = "Não"
                },
                Torax = new {
                    Id = 'N',
                    Name = "Não"
                },
                Membros = new {
                    Id = 'N',
                    Name = "Não"
                },
                Coluna = new {
                    Id = 'N',
                    Name = "Não"
                },
                ExameGer = new {
                    Id = 'N',
                    Name = "Não"
                },
                Abdome = new {
                    Id = 'N',
                    Name = "Não"
                },
                Imunizacao = new {
                    Id = 'N',
                    Name = "Não"
                },
                BioComport = new {
                    Id = 'N',
                    Name = "Não"
                },
                CabecaPescoco = new {
                    Id = 'N',
                    Name = "Não"
                },
                CondTrab = new {
                    Id = 'N',
                    Name = "Não"
                },
                AcidTrab = new {
                    Id = 'N',
                    Name = "Não"
                },
                Faixa = new {
                    Id = 'N',
                    Name = "Não"
                },
                ColabResp = new {
                    Id = 'N',
                    Name = "Não"
                },
                ColabAtend = new {
                    Id = 'S',
                    Name =  "Sim"
                },
                QtdEspectad = new {
                    Id = 'N',
                    Name = "Não"
                },
                IndiSerie = new {
                    Id = 'N',
                    Name = "Não"
                },
                Assistencial = new {
                    Id = 'S',
                    Name = "Sim"
                },
                TotAtend = new {
                    Id = 'N',
                    Name = "Não"
                },
                Evento = new {
                    Id = 'N',
                    Name = "Não"
                },
                Tema = new {
                    Id = 'N',
                    Name = "Não"
                },
                QtdAtend = new {
                    Id = 'N',
                    Name = "Não"
                },
                Entidade = new {
                    Id = 'O',
                    Name = "Opcional"
                },
                Pessoa = new {
                    Id = 'S',
                    Name = "Sim"
                },
                TipoUtilizacao = new {
                    Id =  '2',
                    Name = "SCA"
                },
                Umo = new {
                    Id =  'N',
                    Name = "Não"
                },
                PrimVez = new {
                    Id =  'N',
                    Name = "Não"
                },
                PrimeSpec = new {
                    Id =  'N',
                    Name = "Não"
                },
                Dente = new {
                    Id =  'N',
                    Name = "Não"
                },
                Valor = new {
                    Id =  'N',
                    Name = "Não"
                },
                QtPesAtend = new {
                    Id =  'N',
                    Name = "Não"
                },
                Turma = new {
                    Id =  'N',
                    Name = "Não"
                },
                EntPrestadora = new {
                    Id =  'N',
                    Name = "Não"
                },
                TipoPreenchimento = new {
                    Id = 'S',
                    Name = "Preenchimento Obrigatorio"
                },
                PublAlvo = new {
                    Id = 'N',
                    Name = "Não"
                },
                Despesa = new {
                    Id = 'N',
                    Name = "Não"
                },
                Receita = new {
                    Id = 'N',
                    Name = "Não"
                },
                CidDeficiencia = new {
                    Id = 'N',
                    Name = "Não"
                },
                GeraAtendimento = new {
                    Id = 'N',
                    Name = "Não"
                },
                Id = 9999,
                Descricao = $"TESTE TDD {RandTest}",
            };

            Configure("Gestor/TiposFichas", "1");
        }
    }
}