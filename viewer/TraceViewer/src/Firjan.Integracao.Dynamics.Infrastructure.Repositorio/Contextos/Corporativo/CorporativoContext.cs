using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.STI;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Gestor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using FluentValidation.Results;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.STI;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.Corporativo.SRC;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Hosting;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Maps.SGE;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.Corporativo
{
    public class CorporativoContext : DbContext
    {
        public CorporativoContext(DbContextOptions<CorporativoContext> options, IHostingEnvironment env)
            : base(options)
        {

#if DEBUG
            this.ConfigureLogging(s => Console.Write(s), LoggingCategories.SQL);
#endif
            int? e = this.Database.GetCommandTimeout();

            this.Database.SetCommandTimeout(e.HasValue ? e + 1200 : 1200);
        }

        public DbSet<Domain.Models.Corporativo.STI.Area> Areas { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<TipoFicha> TiposFichas { get; set; }
        public DbSet<UnidadeNegocio> UnidadeNegocios { get; set; }
        public DbSet<UnidadeFederativa> UnidadesFederativas { get; set; }
        public DbSet<EmpresaSistemaCNICoordenadora> EmpresasSistemaCNI { get; set; }
        public DbSet<ItemContabil> ItensContabeis { get; set; }
        public DbSet<ClasseValor> ClassesValores { get; set; }
        public DbSet<ContaContabil> ContasContabeis { get; set; }
        public DbSet<LinhaServico> LinhasServicos { get; set; }
        public DbSet<ProdutoUnidadeNegocio> ProdutosUnidadeNegocios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<EnderecoUnidade> EnderecosUnidades { get; set; }
        public DbSet<TipoRegiao> TiposRegioes { get; set; }
        public DbSet<UF> UFs { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<RegiaoUnidadeNegocio> RegioesUnidadesNegocios { get; set; }
        public DbSet<CodigoMunicipal> CodigosMunicipais { get; set; }
        public DbSet<ClassificacaoServico> ClassificacoesServicos { get; set; }
        public DbSet<TipoEntidadeVinculo> TiposEntidadesVinculos { get; set; }
        public DbSet<Entidade> Entidades { get; set; }
        public DbSet<ProdutoTipoFicha> ProdutosTipoFichas { get; set; }
        public DbSet<CentroCusto> CentrosCustos { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<TipoUnidadeNegocioTipoEntidadeVinculo> TiposUnidadeNegociosTiposEntidadesVinculos { get; set; }
        public DbSet<TipoServico> TiposServicos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Domain.Models.Corporativo.Gestor.GrupoClassificacao> GruposClassificacoes { get; set; }
        public DbSet<TUSS> TUSSES { get; set; }
        public DbSet<ItemContabilProduto> ItemsContabeisProdutos { get; set; }
        public DbSet<ContaContabilProduto> ContasContabeisProdutos { get; set; }
        public DbSet<ClasseValorProduto> ClassesValoresProdutos { get; set; }
        public DbSet<Domain.Models.Corporativo.Protheus.Empresa> EmpresasProtheus { get; set; }
        public DbSet<Domain.Models.Corporativo.Gestor.Empresa> Empresas { get; set; }
        public DbSet<EmpresaEntidadeVinculo> EmpresasEntidadesVinculos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<TipoModalidade> TiposModalidades { get; set; }
        public DbSet<PortifolioEducacao> PortifolliosEducacoes { get; set; }
        public DbSet<Instrucao> Instrucoes { get; set; }
        public DbSet<ModuloVersao> ModulosVersoes { get; set; }
        public DbSet<NaturezaServico> NaturezasServicos { get; set; }
        public DbSet<TabelaServicoTipoEntidadeVinculo> TabelaServicosTipoEntidadesVinculos { get; set; }
        public DbSet<ClassificacaoExame> ClassificacoesExames { get; set; }
        public DbSet<TipoRisco> TipoRiscos { get; set; }
        public DbSet<Risco> Riscos { get; set; }
        public DbSet<Saude> Saudes { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<FiguraOdontograma> FigurasOdontogramas { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<SaudeFiguraOdontograma> SaudesFigurasOdontogramas { get; set; }
        public DbSet<TipoCliente> TiposClientes { get; set; }
        public DbSet<TipoContrato> TiposContratos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Odontograma> Odontogramas { get; set; }
        public DbSet<Lazer> Lazeres { get; set; }
        public DbSet<AreaDN> AreasDNs { get; set; }

        public int GetLastIncrementID<TEntity>() where TEntity : class
        {
            DbSet<TEntity> table = Set<TEntity>();
            var lastRecord = table.OrderBy("Id",false).FirstOrDefault();
            var idProperty = lastRecord.GetType().GetProperty("Id").GetValue(lastRecord);
            var maxId = Convert.ToInt32(idProperty) +1;
            return  maxId;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Ignore<ValidationFailure>();

            modelBuilder
                .Ignore<ValidationResult>();

            modelBuilder
                .ApplyConfiguration(new RamoAtividadeMap());

            modelBuilder
                .ApplyConfiguration(new TipoRegimentoMap());

            modelBuilder.ApplyConfiguration(new GeneroMap());

            modelBuilder
                .ApplyConfiguration(new TipoEntidadeVinculoMap());

            modelBuilder
                .ApplyConfiguration(new EntidadeMap());

            modelBuilder
                .ApplyConfiguration(new FuncaoMap()) ;

            modelBuilder
                .ApplyConfiguration(new AreaMap());

            modelBuilder
                .ApplyConfiguration(new PlataformaMap());

            modelBuilder
                .ApplyConfiguration(new TipoFichaMap());

            modelBuilder
                .ApplyConfiguration(new EmpresaSistemaCNICoordenadoraMap());

            modelBuilder
                .ApplyConfiguration(new UnidadeNegocioMap());

            modelBuilder
                .ApplyConfiguration(new UFMap());

            modelBuilder
                .ApplyConfiguration(new MunicipioMap());

            modelBuilder
                .ApplyConfiguration(new TipoServicoMap());

            modelBuilder
                .ApplyConfiguration(new NivelServicoMap());

            modelBuilder
                .ApplyConfiguration(new TabelaServicoMap());

            modelBuilder
                .ApplyConfiguration(new GrupoClassificacaoMap());

            modelBuilder
                .ApplyConfiguration(new TUSSMap());

            modelBuilder
                .ApplyConfiguration(new ProdutoMap());

            modelBuilder
                .ApplyConfiguration(new CodigoMunicipalMap());

            modelBuilder
                .ApplyConfiguration(new CodigoMunicipalServicoCorporativoMap());

            modelBuilder
                .ApplyConfiguration(new ItemContabilMap());

            modelBuilder
                .ApplyConfiguration(new ClasseValorMap());

            modelBuilder
                .ApplyConfiguration(new ContaContabilMap());

            modelBuilder
                .ApplyConfiguration(new LinhaServicoMap());

            modelBuilder
                .ApplyConfiguration(new ProdutoUnidadeNegocioMap());

            modelBuilder
                .ApplyConfiguration(new TipoRegiaoMap());

            modelBuilder
                .ApplyConfiguration(new MunicipioMap());

            modelBuilder
                .ApplyConfiguration(new BairroMap());

            modelBuilder
                .ApplyConfiguration(new EnderecoUnidadeMap());

            modelBuilder
                .ApplyConfiguration(new RegiaoMap());

            modelBuilder
                .ApplyConfiguration(new RegiaoUnidadeNegocioMap());

            modelBuilder
                .ApplyConfiguration(new ClassificacaoServicoMap());

            modelBuilder
                .ApplyConfiguration(new TipoUnidadeNegocioMap());

            modelBuilder
                .ApplyConfiguration(new TipoUnidadeNegocioTipoEntidadeVinculoMap());

            modelBuilder
                .ApplyConfiguration(new EntidadeMap());

            modelBuilder
                .ApplyConfiguration(new ProdutoTipoFichaMap());

            modelBuilder
                .ApplyConfiguration(new CentroCustoMap());

            modelBuilder
                .ApplyConfiguration(new FilialMap());

            modelBuilder
                .ApplyConfiguration(new ItemContabilProdutoMap());

            modelBuilder
                .ApplyConfiguration(new ContaContabilProdutoMap());

            modelBuilder
                .ApplyConfiguration(new ClasseValorProdutoMap());

            modelBuilder
                .ApplyConfiguration(new Maps.Corporativo.Gestor.EmpresaMap());

            modelBuilder
                .ApplyConfiguration(new Maps.Protheus.EmpresaMap());

            modelBuilder
                .ApplyConfiguration(new ModalidadeMap());

            modelBuilder
                .ApplyConfiguration(new TipoModalidadeMap());

            modelBuilder
                .ApplyConfiguration(new PortifolioEducacaoMap());

            modelBuilder
                .ApplyConfiguration(new InstrucaoMap());

            modelBuilder
                .ApplyConfiguration(new NaturezaServicoMap());

            modelBuilder
                .ApplyConfiguration(new ModuloVersaoMap());

            modelBuilder
                .ApplyConfiguration(new TabelaServicoTipoEntidadeVinculoMap());

            modelBuilder
                .ApplyConfiguration(new ClassificacaoExameMap());

            modelBuilder
                .ApplyConfiguration(new TipoRiscoMap());

            modelBuilder
                .ApplyConfiguration(new RiscoMap());

            modelBuilder
                .ApplyConfiguration(new AgenteMap());

            modelBuilder
                .ApplyConfiguration(new SaudeFiguraOdontogramaMap());

            modelBuilder
                .ApplyConfiguration(new SaudeMap());

            modelBuilder
                .ApplyConfiguration(new FiguraOdontogramaMap());

            modelBuilder
                .ApplyConfiguration(new ColaboradorMap());

            modelBuilder
                .ApplyConfiguration(new PessoaMap());

            modelBuilder
                .ApplyConfiguration(new TipoContratoMap());

            modelBuilder
                .ApplyConfiguration(new ContratoMap());

            modelBuilder
                .ApplyConfiguration(new TipoClienteMap());

            modelBuilder
                .ApplyConfiguration(new AtendimentoMap());

            modelBuilder
                .ApplyConfiguration(new OdontogramaMap());

            modelBuilder
                .ApplyConfiguration(new ServicoMap());

            modelBuilder
                .ApplyConfiguration(new LazerMap());

            modelBuilder
                .ApplyConfiguration(new AreaDNMap());

            modelBuilder
                .ApplyConfiguration(new EmpresaEntidadeVinculoMap());

            modelBuilder
                .Entity<Produto>()
                .HasQueryFilter(c => (c.Fim == null || c.Fim > DateTime.Now) && (c.Validade == null || c.Validade >= DateTime.Now));

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
               .ConfigureWarnings(bulder =>
                      bulder
                      .Default(WarningBehavior.Ignore)
                      .Log(CoreEventId.IncludeIgnoredWarning, CoreEventId.SaveChangesCompleted)
                      .Throw(RelationalEventId.QueryClientEvaluationWarning)
               );


            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}