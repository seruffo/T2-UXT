
using Firjan.Integracao.Dynamics.Application.ViewModels;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.ViewModels.SGE;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using AutoMapper;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.ViewModels.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Models;

namespace Firjan.Integracao.Dynamics.Application.AutoMapperConfigs
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<TraceViewModel, Trace>();

            CreateMap<TUSSViewModel, TUSS>();

            CreateMap<LinhaServicoViewModel, LinhaServico>();

            CreateMap<ClassificacaoServicoViewModel, ClassificacaoServico>()
             .ForMember(dest => dest.LinhaServicoId, opt => opt.MapFrom(t => t.LinhaServicoId))
             .ForMember(dest => dest.LinhaServico, opt => opt.MapFrom(t => t.LinhaServico));

            CreateMap<EspecialidadeView, Especialidade>()
                .ConstructUsing(s => new Especialidade(s.Key, s.Name));

            CreateMap<TipoServicoView, Domain.Models.Corporativo.Gestor.Tipos.TipoServico>()
                .ConstructUsing(s => new Domain.Models.Corporativo.Gestor.Tipos.TipoServico(s.Key, s.Name));

            CreateMap<GrupoClassificacaoViewModel, GrupoClassificacao>();

            CreateMap<TabelaServicoViewModel, TabelaServico>();

            CreateMap<NivelServicoViewlModel, NivelServico>();

            CreateMap<TipoServicoViewModel, Domain.Models.Corporativo.Gestor.TipoServico>();

            CreateMap<UFViewModel, UF>();

            CreateMap<TipoRegiaoViewModel, TipoRegiao>();

            CreateMap<FilialViewModel, Filial>();

            CreateMap<MunicipioViewModel, Municipio>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.SiglaUF, opt => opt.MapFrom(src => src.SiglaUF))
                .ForMember(dest => dest.UF, opt => opt.MapFrom(src => src.UFViewModel))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.CEP));

            CreateMap<BairroViewModel, Bairro>()
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.CodigoMunicipio));

            CreateMap<EnderecoUnidadeViewModel, EnderecoUnidade>(); ;

            CreateMap<RegiaoViewModel, Regiao>();

            CreateMap<GeneroViewModel, Genero>();

            CreateMap<RamoAtividadeViewModel, RamoAtividade>();

            CreateMap<TipoEntidadeVinculoViewModel, Domain.Models.Corporativo.Gestor.TipoEntidadeVinculo>();

            CreateMap<TipoRegimentoViewModel, Domain.Models.Corporativo.Gestor.TipoRegimento>();

            CreateMap<EmpresaSistemaCNICoordenadoraViewModel, EmpresaSistemaCNICoordenadora>();

            CreateMap<ViewModels.Corporativo.SRC.EntidadeViewModel, Entidade>()
                .ForMember(dest => dest.TipoEntidadeVinculoId, opt => opt.MapFrom(src => src.TipoEntidadeVinculoId))
                .ForMember(dest => dest.TipoEntidadeVinculo, opt => opt.MapFrom(src => src.TipoEntidadeVinculo));

            CreateMap<GrupoClassificacaoViewModel, GrupoClassificacao>();

            CreateMap<ViewModels.Protheus.EmpresaViewModel, Domain.Models.Corporativo.Protheus.Empresa>();

            CreateMap<ViewModels.Corporativo.Gestor.EmpresaViewModel, Domain.Models.Corporativo.Gestor.Empresa>();

            CreateMap<CentroCustoViewModel, CentroCusto>();               

            CreateMap<EstabelecimentoViewModel, Estabelecimento>();

            CreateMap<UnidadeNegocioViewModel, UnidadeNegocio>();

            CreateMap<ProdutoUnidadeNegocioViewModel, ProdutoUnidadeNegocio>();

            CreateMap<CaixasViewModel, Caixas>();

            CreateMap<CodigoMunicipalServicoCorporativoViewModel, CodigoMunicipalServicoCorporativo>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.Municipio, opt => opt.MapFrom(t => t.Municipio));

            CreateMap<TipoFichaViewModel, TipoFicha>();

            CreateMap<AreaViewModel, Domain.Models.Corporativo.STI.Area>();

            CreateMap<AreaSGEViewModel, Domain.Models.SGE.Area>();

            CreateMap<ColigadaViewModel, Coligada>();

            CreateMap<ModalidadeCursoViewModel, ModalidadeCurso>();

            CreateMap<ItemContabilViewModel, ItemContabil>();

            CreateMap<ClasseValorViewModel, ClasseValor>();

            CreateMap<ContaContabilViewModel, ContaContabil>();

            CreateMap<RegiaoUnidadeNegocioViewModel, RegiaoUnidadeNegocio>();

            CreateMap<CodigoMunicipalViewModel, CodigoMunicipal>();            

            CreateMap<UnidadeVinculadaView, UnidadeVinculada>()
                .ConstructUsing(s => new UnidadeVinculada(s.Key, s.Name));

            CreateMap<TipoUnidadeNegocioViewModel, TipoUnidadeNegocio>();

            CreateMap<TipoUnidadeNegocioTipoEntidadevinculoViewModel, TipoUnidadeNegocioTipoEntidadeVinculo>();

            CreateMap<DivulgadoView, Divulgado>();

            CreateMap<ValeCulturaView, ValeCultura>()
                .ConstructUsing(s => new ValeCultura(s.Key, s.Name));

            CreateMap<AtendimentoView, Domain.Models.Corporativo.Gestor.Tipos.Atendimento>()
                .ConstructUsing(s => new Domain.Models.Corporativo.Gestor.Tipos.Atendimento(s.Id, s.Name));

            CreateMap<ClassificacaoExameViewModel, ClassificacaoExame>();

            CreateMap<TipoServicoView, Domain.Models.Corporativo.Gestor.Tipos.TipoServico>()
                .ConstructUsing(s => new Domain.Models.Corporativo.Gestor.Tipos.TipoServico(s.Key, s.Name));

            CreateMap<ItemContabilProdutoViewModel, ItemContabilProduto>();

            CreateMap<ContaContabilProdutoViewModel, ContaContabilProduto>();

            CreateMap<ClasseValorProdutoViewModel, ClasseValorProduto>();

            CreateMap<AcaoView, Acao>()
                .ConstructUsing(s => new Acao(s.Id, s.Name));

            CreateMap<ModalidadeViewModel, Modalidade>();

            CreateMap<TipoModalidadeViewModel, TipoModalidade>()
                .ForMember(dest => dest.Acao, opt => opt.MapFrom(src => src.Acao));

            CreateMap<InstrucaoViewModel, Instrucao>();
            CreateMap<TipoModuloView, TipoModulo>();
            CreateMap<PortifolioEducacaoViewModel, PortifolioEducacao>();

            CreateMap<TipoEntidadeView, TipoEntidade>();

            CreateMap<FlagView, Flag>()
                .ConstructUsing(s => new Flag(s.Key,s.Name));

            CreateMap<ContemDisciplinaView, ContemDisciplina>();
            CreateMap<GeraNumeroCertificadoView, GeraNumeroCertificado>();
            CreateMap<RefazCursoView, RefazCurso>();

            CreateMap<TipoResultadoView, TipoResultado>()
                .ConstructUsing(s => new TipoResultado(s.Id, s.Name));

            CreateMap<DivulgadoView, Divulgado>()
                .ConstructUsing(s => new Divulgado(s.Key, s.Name));

            CreateMap<EspecialidadeView, Especialidade>()
                .ConstructUsing(s => new Especialidade(s.Key, s.Name));

            CreateMap<CustoSistemaView, CustoSistema>()
                .ConstructUsing(s => new CustoSistema(s.Key, s.Name));

            CreateMap<ObrigaAreaView, ObrigaArea>()
                .ConstructUsing(s => new ObrigaArea(s.Key, s.Name));

            CreateMap<ObrigaCustoView, ObrigaCusto>()
                .ConstructUsing(s => new ObrigaCusto(s.Key, s.Name));

            CreateMap<ModuloVersaoViewModel, ModuloVersao>()
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(src => src.Produto));

            CreateMap<TabelaServicoTipoEntidadeVinculoViewModel, TabelaServicoTipoEntidadeVinculo>();

            CreateMap<TipoProcedimentoView, TipoProcedimento>()
                .ConstructUsing(s => new TipoProcedimento(s.Id, s.Name));

            CreateMap<TipoServicoOdontologicoView, TipoServicoOdontologico>()
                .ConstructUsing(s => new TipoServicoOdontologico(s.Key, s.Name));

            CreateMap<GuiaCobrancaSemPFOView, GuiaCobrancaSemPFO>()
                .ConstructUsing(s => new GuiaCobrancaSemPFO(s.Key, s.Name));

            CreateMap<MarcarHoraView, MarcarHora>()
                .ConstructUsing(s => new MarcarHora(s.Key, s.Name));
                       
            CreateMap<TipoClassificacaoView, TipoClassificacao>()
                .ConstructUsing(s => new TipoClassificacao(s.Key, s.Name));

            CreateMap<TipoOrigemServicoView, TipoOrigemServico>()
                .ConstructUsing(s => new TipoOrigemServico(s.Id, s.Name));

            CreateMap<SaudeViewModel, Saude>()
                .ForMember(dest => dest.TipoProcedimento, opt => opt.MapFrom(src => src.TipoProcedimento));

            CreateMap<FiguraOdontogramaViewModel, FiguraOdontograma>();

            CreateMap<SaudeFiguraOdontogramaViewModel, SaudeFiguraOdontograma>();

            CreateMap<OdontogramaViewModel, Odontograma>();

            CreateMap<TipoRiscoViewModel, TipoRisco>();

            CreateMap<ViewModels.Corporativo.Gestor.RiscoViewModel, Risco>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.TipoRisco, opt => opt.MapFrom(src => src.TipoRisco)); ;

            CreateMap<QuantificavelView, Quantificavel>()
                .ConstructUsing(s => new Quantificavel(s.Key, s.Name));

            CreateMap<AgenteViewModel, Agente>();

            CreateMap<AreaDNViewModel, AreaDN>();

            CreateMap<NaturezaServicoViewModel, NaturezaServico>();

            CreateMap<ServicoViewModel, Servico>();

            CreateMap<LazerViewModel, Lazer>()
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(t => t.Produto));

            CreateMap<ProdutoViewModel, Produto>()
                .ForMember(dest => dest.Lazer, opt => opt.MapFrom(src => src.Lazer));

            CreateMap<AreaNegocioViewModel, AreaNegocio>();            

            CreateMap<ProdutoTipoFichaViewModel, ProdutoTipoFicha>()
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(t => t.Produto));

            CreateMap<ExameViewModel, Domain.Models.SMAIS.Exame>()
                .ForMember(dest => dest.ATIVO, opt => opt.MapFrom(t => t.Ativo))
                .ForMember(dest => dest.COD, opt => opt.MapFrom(t => t.Codigo))
                .ForMember(dest => dest.DESCRICAO, opt => opt.MapFrom(t => t.Descricao));

            CreateMap<ViewModels.SMAIS.RiscoViewModel, Domain.Models.SMAIS.Risco>()
                .ForMember(dest => dest.COD, opt => opt.MapFrom(t => t.Codigo))
                .ForMember(dest => dest.NOME, opt => opt.MapFrom(t => t.Nome))
                .ForMember(dest => dest.CD_AGENTE_ESOCIAL, opt => opt.MapFrom(t => t.CodigoAgenteESocial));

            CreateMap<FuncaoViewModel, Funcao>();

            CreateMap<PlataformaViewModel, Plataforma>()                 
            .ForMember(dest => dest.Area, opt => opt.MapFrom(t => t.Area));
        }           
    }
}
