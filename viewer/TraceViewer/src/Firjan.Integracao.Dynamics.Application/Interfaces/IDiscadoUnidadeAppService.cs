using Firjan.Integracao.Dynamics.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Application.Interfaces
{
    public interface IDiscadoUnidadeAppService : IDisposable
    {
        Task<DiscadoUnidadeViewModel> Adicionar(DiscadoUnidadeViewModel item);
        Task<DiscadoUnidadeViewModel> Atualizar(DiscadoUnidadeViewModel item);
        Task<IEnumerable<DiscadoUnidadeViewModel>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<DiscadoUnidadeViewModel, bool>> filtro, int qtd, int pule, IEnumerable<string> includes);
    }
}
