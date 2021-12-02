using AutoMapper;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.ViewModels;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Saude;

using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo;
using Firjan.Integracao.Dynamics.Domain.Models.SGE;
using Firjan.Integracao.Dynamics.Application.ViewModels.SGE;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.ViewModels.Protheus;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Tipos.Base;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.ViewModels.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Models;

namespace Firjan.Integracao.Dynamics.Application.AutoMapperConfigs
{

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Trace, TraceViewModel>();

            CreateMap<TUSS, TUSSViewModel>();

            CreateMap<LinhaServico, LinhaServicoViewModel>()
                .ForMember(dest => dest.FuncaoViewModel, opt => opt.MapFrom(src => src.Funcao));

            CreateMap<ClassificacaoServico, ClassificacaoServicoViewModel>()
                .ForMember(dest => dest.LinhaServicoId, opt => opt.MapFrom(src => src.LinhaServicoId))
                .ForMember(dest => dest.LinhaServico, opt => opt.MapFrom(src => src.LinhaServico));

            CreateMap<Especialidade, EspecialidadeView>()
                .ConstructUsing(s => new EspecialidadeView(s.Id, s.Name));

            CreateMap<Domain.Models.Corporativo.Gestor.Tipos.TipoServico, TipoServicoView>()
                .ConstructUsing(s => new TipoServicoView(s.Id, s.Name));

            CreateMap<GrupoClassificacao, GrupoClassificacaoViewModel>();

            CreateMap<TabelaServico, TabelaServicoViewModel>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));

            CreateMap<NivelServico, NivelServicoViewlModel>();

            CreateMap<Domain.Models.Corporativo.Gestor.TipoServico, TipoServicoViewModel>();

            CreateMap<Domain.Models.Corporativo.Gestor.TipoEntidadeVinculo, TipoEntidadeVinculoViewModel>();

            CreateMap<Domain.Models.Corporativo.STI.Area, AreaViewModel>();

            CreateMap<Coligada, ColigadaViewModel>();

            CreateMap<ModalidadeCurso, ModalidadeCursoViewModel>()
                .ForMember(dest => dest.Coligada, opt => opt.MapFrom(src => src.Coligada))
                .ForMember(dest => dest.ColigadaId, opt => opt.MapFrom(src => src.ColigadaId));

            CreateMap<UF, UFViewModel>();

            CreateMap<Filial, FilialViewModel>();

            CreateMap<Municipio, MunicipioViewModel>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.SiglaUF, opt => opt.MapFrom(src => src.SiglaUF))
                .ForMember(dest => dest.UFViewModel, opt => opt.MapFrom(src => src.UF))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.CEP));

            CreateMap<Bairro, BairroViewModel>()
                .ForMember(dest => dest.CodigoMunicipio, opt => opt.MapFrom(src => src.MunicipioId));

            CreateMap<EnderecoUnidade, EnderecoUnidadeViewModel>();

            CreateMap<TipoRegiao, TipoRegiaoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.ValidationResult, opt => opt.MapFrom(src => src.ValidationResult));

            CreateMap<Regiao, RegiaoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EnderecoUnidadeId, opt => opt.MapFrom(src => src.EnderecoUnidadeId))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.TipoRegiao, opt => opt.MapFrom(src => src.TipoRegiao))
                .ForMember(dest => dest.EnderecoUnidade, opt => opt.MapFrom(src => src.EnderecoUnidade));

            CreateMap<Genero, GeneroViewModel>();
            CreateMap<RamoAtividade, RamoAtividadeViewModel>();

            CreateMap<UnidadeVinculada, UnidadeVinculadaView>()
                .ConstructUsing(s => new UnidadeVinculadaView(s.Id, s.Name));

            CreateMap<TipoUnidadeNegocio, TipoUnidadeNegocioViewModel>();

            CreateMap<TipoUnidadeNegocioTipoEntidadeVinculo, TipoUnidadeNegocioTipoEntidadevinculoViewModel>();

            CreateMap<Domain.Models.Corporativo.Gestor.TipoRegimento, TipoRegimentoViewModel>();

            CreateMap<Domain.Models.Corporativo.Protheus.Empresa, ViewModels.Protheus.EmpresaViewModel>();

            CreateMap<Domain.Models.Corporativo.Gestor.Empresa, ViewModels.Corporativo.Gestor.EmpresaViewModel>();

            CreateMap<GrupoClassificacao, GrupoClassificacaoViewModel>();

            CreateMap<Entidade, ViewModels.Corporativo.SRC.EntidadeViewModel>()
                .ForMember(dest => dest.TipoEntidadeVinculoId, opt => opt.MapFrom(src => src.TipoEntidadeVinculoId))
                .ForMember(dest => dest.TipoEntidadeVinculo, opt => opt.MapFrom(src => src.TipoEntidadeVinculo));

            CreateMap<Funcao, FuncaoViewModel>();

            CreateMap<Plataforma, PlataformaViewModel>()
                 .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area));

            CreateMap<CentroCusto, CentroCustoViewModel>();

            CreateMap<Estabelecimento, EstabelecimentoViewModel>();
            CreateMap<Caixas, CaixasViewModel>();

            CreateMap<UnidadeNegocio, UnidadeNegocioViewModel>();

            CreateMap<EmpresaSistemaCNICoordenadora, EmpresaSistemaCNICoordenadoraViewModel>();

            CreateMap<CodigoMunicipalProduto, CodigoMunicipalProdutoViewModel>();
            CreateMap<CodigoMunicipalServicoCorporativo, CodigoMunicipalServicoCorporativoViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<TipoFicha, TipoFichaViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.ValidationResult, opt => opt.MapFrom(src => src.ValidationResult));

            CreateMap<Domain.Models.SGE.Area, AreaSGEViewModel>();

            CreateMap<ItemContabil, ItemContabilViewModel>();

            CreateMap<ClasseValor, ClasseValorViewModel>();

            CreateMap<ContaContabil, ContaContabilViewModel>();

            CreateMap<ProdutoUnidadeNegocio, ProdutoUnidadeNegocioViewModel>();

            CreateMap<RegiaoUnidadeNegocio, RegiaoUnidadeNegocioViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.UnidadeNegocioId, opt => opt.MapFrom(src => src.UnidadeNegocioId))
                .ForMember(dest => dest.Unidadenegocio, opt => opt.MapFrom(src => src.UnidadeNegocio))
                .ForMember(dest => dest.TipoRegiaoId, opt => opt.MapFrom(src => src.TipoRegiaoId))
                .ForMember(dest => dest.TipoRegiao, opt => opt.MapFrom(src => src.TipoRegiao))
                .ForMember(dest => dest.RegiaoId, opt => opt.MapFrom(src => src.RegiaoId))
                .ForMember(dest => dest.Regiao, opt => opt.MapFrom(src => src.Regiao))
                .ForMember(dest => dest.Inicio, opt => opt.MapFrom(src => src.Inicio))
                .ForMember(dest => dest.Fim, opt => opt.MapFrom(src => src.Fim));

            CreateMap<CodigoMunicipal, CodigoMunicipalViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(t => t.Descricao))
                .ForMember(dest => dest.Municipio, opt => opt.MapFrom(t => t.Municipio))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(t => t.MunicipioId))
                .ForMember(dest => dest.CoodigoMunicipio, opt => opt.MapFrom(t => t.CoodigoMunicipio));

            CreateMap<Divulgado, DivulgadoView>();

            CreateMap<ValeCultura, ValeCulturaView>()
                .ConstructUsing(s => new ValeCulturaView(s.Id, s.Name));
            
            CreateMap<Domain.Models.Corporativo.Gestor.Tipos.Atendimento, AtendimentoView>()
                .ConstructUsing(s => new AtendimentoView(s.Id, s.Name));

            CreateMap<ClassificacaoExame, ClassificacaoExameViewModel>();

            CreateMap<Domain.Models.Corporativo.Gestor.Tipos.TipoServico, TipoServicoView>()
                .ConstructUsing(s => new TipoServicoView(s.Id, s.Name));

            CreateMap<ItemContabilProduto, ItemContabilProdutoViewModel>();

            CreateMap<ContaContabilProduto, ContaContabilProdutoViewModel>();

            CreateMap<ClasseValorProduto, ClasseValorProdutoViewModel>();

            CreateMap<Acao, AcaoView>()
                .ConstructUsing(s => new AcaoView(s.Key, s.Name));

            CreateMap<Modalidade, ModalidadeViewModel>();

            CreateMap<TipoModalidade, TipoModalidadeViewModel>()
                .ForMember(dest => dest.Acao, opt => opt.MapFrom(src => src.Acao));

            CreateMap<Instrucao, InstrucaoViewModel>();
            CreateMap<TipoModulo, TipoModuloView>();
            CreateMap<PortifolioEducacao, PortifolioEducacaoViewModel>();

            CreateMap<TipoResultado, TipoResultadoView>()
                .ConstructUsing(s => new TipoResultadoView(s.Id, s.Name));

            CreateMap<TipoEntidade, TipoEntidadeView>();

            CreateMap<Flag, FlagView>()
               .ConstructUsing(s => new FlagView(s.Id, s.Name));

            CreateMap<ContemDisciplina, ContemDisciplinaView>();

            CreateMap<TipoProcedimento, TipoProcedimentoView>()
                .ConstructUsing(s => new TipoProcedimentoView(s.Id, s.Name));

            CreateMap<GeraNumeroCertificado, GeraNumeroCertificadoView>();
            CreateMap<RefazCurso, RefazCursoView>();

            CreateMap<Divulgado, DivulgadoView>()
                .ConstructUsing(s => new DivulgadoView(s.Id, s.Name));

            CreateMap<Especialidade, EspecialidadeView>()
                .ConstructUsing(s => new EspecialidadeView(s.Id, s.Name));

            CreateMap<CustoSistema, CustoSistemaView>()
               .ConstructUsing(s => new CustoSistemaView(s.Id, s.Name));

            CreateMap<ObrigaArea, ObrigaAreaView>()
                .ConstructUsing(s => new ObrigaAreaView(s.Id, s.Name));

            CreateMap<ObrigaCusto, ObrigaCustoView>()
                .ConstructUsing(s => new ObrigaCustoView(s.Id, s.Name));

            CreateMap<ModuloVersao, ModuloVersaoViewModel>()
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(src => src.Produto));

            CreateMap<TabelaServicoTipoEntidadeVinculo, TabelaServicoTipoEntidadeVinculoViewModel>()
                .IgnoreMap();

            CreateMap<TipoOrigemServico, TipoOrigemServicoView>()
                .ConstructUsing(s => new TipoOrigemServicoView(s.Id, s.Name));

            CreateMap<Saude, SaudeViewModel>()
                .ForMember(dest => dest.TipoProcedimento, opt => opt.MapFrom(src => src.TipoProcedimento));

            CreateMap<FiguraOdontograma, FiguraOdontogramaViewModel>();

            CreateMap<SaudeFiguraOdontograma, SaudeFiguraOdontogramaViewModel>();

            CreateMap<Odontograma, OdontogramaViewModel>();

            CreateMap<TipoRisco, TipoRiscoViewModel>();

            CreateMap<Risco, ViewModels.Corporativo.Gestor.RiscoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.TipoRisco, opt => opt.MapFrom(src => src.TipoRisco));

            CreateMap<Agente, AgenteViewModel>();

            CreateMap<AreaDN, AreaDNViewModel>();

            CreateMap<Lazer, LazerViewModel>()
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(t => t.Produto));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.Lazer, opt => opt.MapFrom(src => src.Lazer));

            CreateMap<AreaNegocio, AreaNegocioViewModel>();

            CreateMap<NaturezaServico, NaturezaServicoViewModel>();

            CreateMap<Servico, ServicoViewModel>();

            CreateMap<ProdutoTipoFicha, ProdutoTipoFichaViewModel>()
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(t => t.Produto));


            CreateMap<Domain.Models.SMAIS.Exame, ExameViewModel>()
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(t => t.ATIVO))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(t => t.COD))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(t => t.DESCRICAO));

            CreateMap<Domain.Models.SMAIS.Risco, ViewModels.SMAIS.RiscoViewModel>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(t => t.COD))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(t => t.NOME))
                .ForMember(dest => dest.CodigoAgenteESocial, opt => opt.MapFrom(t => t.CD_AGENTE_ESOCIAL));
        }
    }
}

