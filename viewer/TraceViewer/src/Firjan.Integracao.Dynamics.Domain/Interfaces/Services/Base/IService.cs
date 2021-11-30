using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Base
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> Atualizar(TEntity entity);
        Task<IEnumerable<TEntity>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<TEntity, bool>> filtro, int qtd, int pule, IEnumerable<string> includes);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filtro, IEnumerable<string> includes);
        Task<TEntity> Remover(TEntity entity);
    }
}
