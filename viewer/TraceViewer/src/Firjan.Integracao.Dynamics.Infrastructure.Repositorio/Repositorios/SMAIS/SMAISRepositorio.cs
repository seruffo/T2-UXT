using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using System.Linq;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SMAIS
{
    public abstract class SMAISRepositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected string urlSMAIS = string.Empty;
        protected SMAISRepositorio(string url) { urlSMAIS = url; }

        public virtual Task<TEntity> Adicionar(TEntity item) { throw new NotImplementedException(); }

        public virtual Task<TEntity> Remover(TEntity item) { throw new NotImplementedException(); }

        public virtual Task<TEntity> Remover(object id) { throw new NotImplementedException(); }

        public virtual Task<TEntity> Atualizar(TEntity item) { throw new NotImplementedException(); }

        public virtual Task<TEntity> ObtemPorId(object id) { throw new NotImplementedException(); }

        public virtual async Task<IEnumerable<TEntity>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<TEntity, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {
            var sbMsgErr = new StringBuilder();
            IEnumerable<TEntity> entities = new List<TEntity>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(urlSMAIS))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        entities = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(apiResponse);
                    }
                }
                catch (CommunicationException ex)
                {
                    sbMsgErr.Append($"{nameof(ComFiltros)} There was a communication problem.{ex.Message} {ex.StackTrace}");
                }
            }

            if (!string.IsNullOrEmpty(colunaOrdenacao))
            {
                var propertyInfo = typeof(TEntity).GetProperty(colunaOrdenacao);
                entities = entities.OrderBy(x => propertyInfo.GetValue(x, null));
            }                

            if (pule > 0)
                entities = entities.Skip(pule);
             
            if (qtd > 0)
                entities = entities.Take(qtd);

            return await Task.FromResult(entities);
        }

        public virtual Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression, IEnumerable<string> includes = null) { throw new NotImplementedException(); }

        public virtual Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression, IEnumerable<string> includes) { throw new NotImplementedException(); }

        public virtual Task<bool> Any(Expression<Func<TEntity, bool>> expression) { throw new NotImplementedException(); }

        public virtual Task<bool> All(Expression<Func<TEntity, bool>> expression) { throw new NotImplementedException(); }

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
              
            }
        }

        public TEntity SetId(TEntity item)
        {
            throw new NotImplementedException();
        }

        ~SMAISRepositorio()
        {
            Dispose(false);
        }
        #endregion
    }
}