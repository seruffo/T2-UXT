using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Base;
using Firjan.Integracao.Dynamics.Application.Utils;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;

namespace Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor
{
    public class HierarquiaProdutoAppService : BaseAppService<GrupoClassificacao, GrupoClassificacaoViewModel>, IHierarquiaProdutoAppService
    {
        protected static readonly string[] includesGrupo = { "TipoEntidadeVinculo", "TipoServico" };
        protected readonly IEmpresaService _empresaService;
        protected readonly IEmpresaEntidadeVinculoService _empresaEntidadeVinculoService;
        protected List<EmpresaViewModel> EmpresasViewModel { get; set; }
        public HierarquiaProdutoAppService(IMapper mapper, IHierarquiaProdutoService service, IEmpresaService empresaService, IEmpresaEntidadeVinculoService empresaEntidadeVinculoService) : base(mapper, service, includesGrupo, null)
        {
            _empresaService = empresaService;
            _empresaEntidadeVinculoService = empresaEntidadeVinculoService;
            EmpresasViewModel = new List<EmpresaViewModel>();
        }

        public Task<List<EmpresaViewModel>> ComFiltrosEntidades(string colunaOrdenacao, bool? asc, Expression<Func<EmpresaViewModel, bool>> filtro, int? qtd, int pule)
        {
            _empresaService.ComFiltros(null, null, filtro.ConvertExpression<EmpresaViewModel, Empresa>(), 0, 0, null).Result
            .ForEach(empresa => {
                var gruposClassificacoes = new List<GrupoClassificacaoViewModel>();
                var tiposENtidadesVinculosIds = _empresaEntidadeVinculoService.GetTiposEntidadesVinculosIds(empresa.Id);
                while (tiposENtidadesVinculosIds.MoveNext())
                {
                    Expression<Func<GrupoClassificacaoViewModel, bool>> instance = c => c.CodigoTipoEntidadeVinculo == tiposENtidadesVinculosIds.Current;
                    
                    _baseService.ComFiltros(null, null, instance.ConvertExpression<GrupoClassificacaoViewModel, GrupoClassificacao>(), 0, 0, includesGrupo).Result
                    .ForEach(grupoClassificacao => { gruposClassificacoes.Add(_mapper.Map<GrupoClassificacaoViewModel>(grupoClassificacao)); });
                }
                EmpresasViewModel.Add(new EmpresaViewModel() { Id = empresa.Id, Descricao = empresa.Descricao, GruposClassificacoes = gruposClassificacoes });
            });

            return Task.FromResult(EmpresasViewModel);
        }
    }
}
