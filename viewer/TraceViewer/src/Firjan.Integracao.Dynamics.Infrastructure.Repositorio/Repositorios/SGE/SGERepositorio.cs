using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Contextos.SGE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SGE
{
    public abstract class SGERepositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SGEContext _contexto;
        protected readonly DbSet<TEntity> _dbSet;

        protected SGERepositorio(SGEContext contexto)
        {
            _contexto = contexto;
            _dbSet = contexto.Set<TEntity>();
        }

        public virtual Task<TEntity> Adicionar(TEntity item) => Task.FromResult(_dbSet.Add(item).Entity);

        public virtual Task<TEntity> Remover(TEntity item) => Task.FromResult(_dbSet.Remove(item).Entity);

        public virtual async Task<TEntity> Remover(object id)
        {
            var item = await _dbSet.FindAsync(id);
            return _dbSet.Remove(item).Entity;
        }

        public virtual Task<TEntity> Atualizar(TEntity item) => Task.FromResult(_dbSet.Update(item).Entity);

        public virtual async Task<TEntity> ObtemPorId(object id) => await _dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<TEntity, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {
            IQueryable<TEntity> result = _dbSet;
            if (filtro != null)
                result = result.Where(filtro);

            if (!string.IsNullOrEmpty(colunaOrdenacao))
                result = result.OrderBy(colunaOrdenacao, asc ?? true);

            if (pule > 0)
                result = result.Skip(pule);

            if (qtd > 0)
                result = result.Take(qtd);

            if (includes != null && includes.Any())
                foreach (var include in includes)
                    result = result.Include(include);

            return await result.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression, IEnumerable<string> includes = null)
        {
            IQueryable<TEntity> result = _dbSet;

            if (includes != null && includes.Any())
                foreach (var include in includes)
                    result = result.Include(include);

            return await result.Where(expression).ToListAsync().ConfigureAwait(true);
        }

        public virtual async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression, IEnumerable<string> includes)
        {
            IQueryable<TEntity> result = _dbSet;

            if (includes != null && includes.Any())
                foreach (var include in includes)
                    result = result.Include(include);

            return await result.FirstOrDefaultAsync(expression);
        }

        public virtual async Task<bool> Any(Expression<Func<TEntity, bool>> expression) => await _dbSet.AnyAsync(expression).ConfigureAwait(true);

        public virtual async Task<bool> All(Expression<Func<TEntity, bool>> expression) => await  _dbSet.AllAsync(expression).ConfigureAwait(true);
  
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contexto.Dispose();
            }
        }

        public TEntity SetId(TEntity item)
        {
            throw new NotImplementedException();
        }

        ~SGERepositorio()
        {
            Dispose(false);
        }
        #endregion
    }
}