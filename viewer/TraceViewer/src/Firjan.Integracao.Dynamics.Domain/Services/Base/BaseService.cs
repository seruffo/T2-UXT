using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Domain.Services.Base
{
    public abstract class BaseService<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        private readonly AbstractValidator<T> _validator;

        protected BaseService(IRepository<T> repository, AbstractValidator<T> validator = null)
        {
            _repository = repository;
            _validator = validator;
        }

        public Task<T> Adicionar(T entity)
        {
            if (_validator == null) 
                throw new ArgumentException("Validator cannot be null into insert action");

            var validated = _validator.Validate(entity);

            entity.GetType().GetProperty("ValidationResult").SetValue(entity, validated, null);

            if (!validated.IsValid)
            {
                return Task.FromResult<T>(entity);
            }

            return _repository.Adicionar(entity);
        }

        public Task<T> Atualizar(T entity)
        {
            if (_validator == null)
                throw new ArgumentException("Validator cannot be null into update action");

            var validated = _validator.Validate(entity);

            entity.GetType().GetProperty("ValidationResult").SetValue(entity, validated, null);

            if (!validated.IsValid)
            {
                return Task.FromResult<T>(entity);
            }

            return _repository.Atualizar(entity);
        }

        public Task<IEnumerable<T>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<T, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {
            return _repository.ComFiltros(colunaOrdenacao, asc, filtro, qtd, pule, includes);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> filtro, IEnumerable<string> includes = null)
        {
            return _repository.FirstOrDefault(filtro, includes);
        }

        public Task<T> Remover(T entity)
        {
            if (_validator == null)
                throw new ArgumentException("Validator cannot be null into remove action");

            var validated = _validator.Validate(entity);

            entity.GetType().GetProperty("ValidationResult").SetValue(entity, validated, null);

            if (!validated.IsValid)
            {
                return Task.FromResult<T>(entity);
            }

            return _repository.Remover(entity);
        }

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
                _repository.Dispose();
            }

        }

        ~BaseService()
        {
            Dispose(false);
        }
        #endregion
    }
}
