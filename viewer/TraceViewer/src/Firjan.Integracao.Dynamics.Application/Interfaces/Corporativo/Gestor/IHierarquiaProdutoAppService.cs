using Firjan.Integracao.Dynamics.Application.Interfaces.Base;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor
{
    public interface IHierarquiaProdutoAppService : IAppService<GrupoClassificacaoViewModel>
    {
        Task<List<EmpresaViewModel>> ComFiltrosEntidades(string colunaOrdenacao, bool? asc, Expression<Func<EmpresaViewModel, bool>> filtro, int? qtd, int pule);
    }
}
