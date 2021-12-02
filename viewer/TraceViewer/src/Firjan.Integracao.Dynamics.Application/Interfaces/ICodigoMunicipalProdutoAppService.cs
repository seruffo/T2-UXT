using Firjan.Integracao.Dynamics.Application.ViewModels;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Application.Interfaces
{
    public interface ICodigoMunicipalProdutoAppService : IDisposable
    {
        Task<CodigoMunicipalProdutoViewModel> Adicionar(CodigoMunicipalProdutoViewModel item);
        Task<CodigoMunicipalProdutoViewModel> Atualizar(CodigoMunicipalProdutoViewModel item);
        Task<IEnumerable<CodigoMunicipalProduto>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<CodigoMunicipalProduto, bool>> filtro, int qtd, int pule, IEnumerable<string> includes);
    }
}
