using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Firjan.Integracao.Dynamics.Application.Interfaces.Base;
using Firjan.Integracao.Dynamics.Application.Utils;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Base;

namespace Firjan.Integracao.Dynamics.Application.Services.Base
{
    public abstract class BaseAppService<E,V>  : IAppService<V>
        where E : class
        where V : class
    {
        protected readonly IMapper _mapper;
        protected readonly IService<E> _baseService;
        protected readonly IEnumerable<string> _includes;
        protected readonly Expression<Func<V, bool>> _expression;
        protected readonly Expression<Func<V, bool>> instance = c => 1 == 1;

        protected BaseAppService(IMapper mapper, IService<E> baseService, IEnumerable<string> includes = null, Expression<Func<V, bool>> expression = null)
        {
            _mapper = mapper;
            _baseService = baseService;
            _includes = includes;
            _expression = expression;
        }

        public virtual Task<V> Adicionar(V itemViewModel)
        {
            var itemMap = _mapper.Map<E>(itemViewModel);
            var item = _baseService.Adicionar(itemMap);
            itemViewModel = _mapper.Map<V>(item.GetAwaiter().GetResult());
            return Task.FromResult(itemViewModel);
        }

        public virtual Task<V> Atualizar(V itemViewModel)
        {
            var itemMap = _mapper.Map<E>(itemViewModel);
            var item = _baseService.Atualizar(itemMap);
            itemViewModel = _mapper.Map<V>(item.GetAwaiter().GetResult());
            return Task.FromResult(itemViewModel);
        }

        public virtual Task<IEnumerable<V>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<V, bool>> filtro, int qtd, int pule)
        {
            if (_expression != null)
            {
                if(filtro == null)
                    filtro = instance;

                filtro = CombineFunction.Combine(filtro,_expression);
            }

            using (var retorno = _baseService.ComFiltros(colunaOrdenacao, asc, filtro.ConvertExpression<V, E>(), qtd, pule, _includes))
            {
                var res = retorno.Result;
                return Task.FromResult(_mapper.Map<IEnumerable<V>>(res));
            }
        }

        public virtual Task<V> FirstOrDefault(Expression<Func<V, bool>> filtro, IEnumerable<string> includes = null)
        {
            using (var retorno = _baseService.FirstOrDefault(filtro.ConvertExpression<V, E>(), includes??_includes))
            {
                var res = retorno.Result;
                return Task.FromResult(_mapper.Map<V>(res));
            }
        }

        public Task<V> Remover(V itemViewModel)
        {
            var itemMap = _mapper.Map<E>(itemViewModel);
            var item = _baseService.Remover(itemMap);
            itemViewModel = _mapper.Map<V>(item.GetAwaiter().GetResult());
            return Task.FromResult(itemViewModel);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
