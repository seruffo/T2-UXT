using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.BaseRepositorio
{
    public abstract class BaseRepositorio<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly DbContext _contexto;
        protected readonly DbSet<TEntity> _dbSet;
        protected ArrayList _parameters;
        protected ArrayList Parameters
        {
            get
            {
                if (_parameters == null)
                {
                    _parameters = new FirjanParameters<string,object>();
                }
                return _parameters;
            }
        }
        protected string StoredProcedure { get; set; }

        protected void AddStroredProcedure(string storedProcedure)
        {
            StoredProcedure = storedProcedure;
        }

        protected void AddParameters(string name, object value)
        {
            Parameters.Add(new SqlParameter(name, value));
        }

        protected BaseRepositorio(DbContext contexto)
        {
            _contexto = contexto;
            _dbSet = contexto.Set<TEntity>();
        }

        public virtual Task<TEntity> Adicionar(TEntity item)
        {
            return SaveChanges(_dbSet.Add(SetIdentity(item)).Entity);
        }

        public virtual Task<TEntity> Remover(TEntity item)
        {
            return Task.FromResult(_dbSet.Remove(item).Entity);
        }

        public virtual async Task<TEntity> Remover(object id)
        {
            var item = await _dbSet.FindAsync(id);
            return _dbSet.Remove(item).Entity;
        }

        private void Validate()
        {
            var entities = _contexto.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();

            foreach (var entity in entities)
            {
                var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
            }
        }

        private Task<TEntity> SaveChanges(TEntity item)
        {
            var sbMsgErr = new StringBuilder();
            try
            {
                Validate();
                _contexto.SaveChanges();
            }
            catch (ValidationException exc)
            {
                sbMsgErr.Append($"{nameof(SaveChanges)} validation exception: {exc?.Message}");
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    Int32 ErrorCode = 0;
                    if (ex.InnerException != null)
                        ErrorCode = ((SqlException)ex.InnerException).Number;
                    else
                        ErrorCode = ((SqlException)ex).Number;

                    switch (ErrorCode)
                    {
                        case 2627:
                            sbMsgErr.Append($"{nameof(SaveChanges)} validation exception Unique constraint error");
                            break;
                        case 547:
                            sbMsgErr.Append($"{nameof(SaveChanges)} validation exception Constraint check violation");
                            break;
                        case 2601:
                            sbMsgErr.Append($"{nameof(SaveChanges)} validation exception Duplicated key row error");
                            break;
                        case 229:
                            sbMsgErr.Append($"{nameof(SaveChanges)} The UPDATE permission was denied on the object");
                            break;
                        case 50001:
                            sbMsgErr.Append($"{nameof(SaveChanges)}  - {ex.Message}");
                            break;
                        default:
                            break;
                    }
                }

                if ((ex.GetBaseException().GetType() == typeof(DbUpdateConcurrencyException)))
                {
                    sbMsgErr.Append($"{nameof(SaveChanges)} Database operation expected to affect 1 row(s) but actually affected 0 row(s)");
                }
            }

            if (sbMsgErr.Length > 0)
                item.GetType()
                    .GetProperty("ValidationResult", typeof(FluentValidation.Results.ValidationResult))
                    .SetValue(item, new FluentValidation.Results.ValidationResult(new List<ValidationFailure> { new ValidationFailure("Error", sbMsgErr.ToString()) }));

            return Task.FromResult(item);
        }

        public virtual Task<TEntity> Atualizar(TEntity item)
        {
            return SaveChanges(_dbSet.Update(item).Entity);
        }

        public virtual async Task<TEntity> ObtemPorId(object id)
        {
            return await _dbSet.FindAsync(id);
        }

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

        public virtual async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression, IEnumerable<string> includes = null)
        {
            IQueryable<TEntity> result = _dbSet;

            if (includes != null && includes.Any())
                foreach (var include in includes)
                    result = result.Include(include);

            return await result.FirstOrDefaultAsync(expression);
        }

        private TEntity SetIdentity(TEntity item)
        {
            var identity = item.GetType().GetProperty("IsIdentity", typeof(bool?));
            if (identity != null)
            {
                var IsIdentity = identity.GetValue(item);
                if (IsIdentity is bool && Convert.ToBoolean(IsIdentity) == false)
                {
                    var maxId = GetLastIncrementID();
                    var type = item.GetType().GetProperty("Id").PropertyType;

                    if (type == typeof(int))
                        item.GetType().GetProperty("Id").SetValue(item, maxId);

                    if (type == typeof(string))
                        item.GetType().GetProperty("Id").SetValue(item, Convert.ToString(maxId));

                    if (type == typeof(Int16))
                        item.GetType().GetProperty("Id").SetValue(item, Convert.ToInt16(maxId));
                }
            }
            return item;
        }

        public TEntity SetId(TEntity item)
        {
            var propValue = item.GetPropValue("Id").GetDBNullOrValue();

            Extensions.Parameters.TryToInt32(propValue, out int value);

            if (value == 0)
            {
                var maxId = GetLastIncrementID();

                var type = item.GetType().GetProperty("Id").PropertyType;

                if (type == typeof(int))
                    item.GetType().GetProperty("Id").SetValue(item, maxId);

                if (type == typeof(string))
                    item.GetType().GetProperty("Id").SetValue(item, Convert.ToString(maxId));

                if (type == typeof(Int16) || type == typeof(Int16?))
                    item.GetType().GetProperty("Id").SetValue(item, Convert.ToInt16(maxId));

                if (type == typeof(Int32) || type == typeof(Int32?))
                    item.GetType().GetProperty("Id").SetValue(item, Convert.ToInt32(maxId));

                if (type == typeof(Int64) || type == typeof(Int64?))
                    item.GetType().GetProperty("Id").SetValue(item, Convert.ToInt64(maxId));

            }

            return item;
        }

        public int GetLastIncrementID()
        {
            DbSet<TEntity> table = _contexto.Set<TEntity>();
            var lastRecord = table.OrderBy("Id", false).FirstOrDefault();
            var idProperty = lastRecord.GetType().GetProperty("Id").GetValue(lastRecord);
            var maxId = Convert.ToInt32(idProperty) + 1;
            return maxId;
        }

        public virtual async Task<bool> Any(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public virtual async Task<bool> All(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AllAsync(expression);
        }

        public int ExecuteStoredProcedure(string storedProcedureName)
        {
            var spSignature = new StringBuilder();
            object[] spParameters;
            var addParameters = (_parameters.ToArray() as IList<SqlParameter>);
            bool hasTableVariables = addParameters.Any(p => p.SqlDbType == SqlDbType.Structured);

            spSignature.AppendFormat("EXECUTE {0}", storedProcedureName);
            var length = addParameters.Count() - 1;

            if (hasTableVariables)
            {
                var tableValueParameters = new List<SqlParameter>();

                for (int i = 0; i < addParameters.Count(); i++)
                {
                    switch (addParameters[i].SqlDbType)
                    {
                        case SqlDbType.Structured:
                            spSignature.AppendFormat("@{0}", addParameters[i].ParameterName);
                            tableValueParameters.Add(addParameters[i]);
                            break;
                        case SqlDbType.VarChar:
                        case SqlDbType.Char:
                        case SqlDbType.Text:
                        case SqlDbType.NVarChar:
                        case SqlDbType.NChar:
                        case SqlDbType.NText:
                        case SqlDbType.Xml:
                        case SqlDbType.UniqueIdentifier:
                        case SqlDbType.Time:
                        case SqlDbType.Date:
                        case SqlDbType.DateTime:
                        case SqlDbType.DateTime2:
                        case SqlDbType.DateTimeOffset:
                        case SqlDbType.SmallDateTime:
                            spSignature.AppendFormat("'{0}'", addParameters[i].Value.ToString());
                            break;
                        default:
                            spSignature.AppendFormat("{0}", addParameters[i].Value.ToString());
                            break;
                    }

                    if (i != length) spSignature.Append(",");
                }
                spParameters = tableValueParameters.Cast<object>().ToArray();
            }
            else
            {
                for (int i = 0; i < addParameters.Count(); i++)
                {
                    spSignature.AppendFormat("@{0}", addParameters[i].ParameterName);
                    if (i != length) spSignature.Append(",");
                }
                spParameters = _parameters.Cast<object>().ToArray();
            }

            var result = _contexto.Database.ExecuteSqlCommand(spSignature.ToString(), spParameters);

            return result;
        }

        private object[] GetParameters(StringBuilder spSignature)
        {
            object[] spParameters;
            var addParameters = _parameters.Cast<SqlParameter>().ToList();
            bool hasTableVariables = addParameters.Any(p => p.SqlDbType == SqlDbType.Structured);
            var length = addParameters.Count() - 1;

            if (hasTableVariables)
            {
                var tableValueParameters = new List<SqlParameter>();

                for (int i = 0; i < addParameters.Count(); i++)
                {
                    switch (addParameters[i].SqlDbType)
                    {
                        case SqlDbType.Structured:
                            spSignature.AppendFormat("@{0}", addParameters[i].ParameterName);
                            tableValueParameters.Add(addParameters[i]);
                            break;
                        case SqlDbType.VarChar:
                        case SqlDbType.Char:
                        case SqlDbType.Text:
                        case SqlDbType.NVarChar:
                        case SqlDbType.NChar:
                        case SqlDbType.NText:
                        case SqlDbType.Xml:
                        case SqlDbType.UniqueIdentifier:
                        case SqlDbType.Time:
                        case SqlDbType.Date:
                        case SqlDbType.DateTime:
                        case SqlDbType.DateTime2:
                        case SqlDbType.DateTimeOffset:
                        case SqlDbType.SmallDateTime:
                            spSignature.AppendFormat("'{0}'", addParameters[i].Value.ToString());
                            break;
                        default:
                            spSignature.AppendFormat("{0}", addParameters[i].Value.ToString());
                            break;
                    }

                    if (i != length) spSignature.Append(",");
                }
                spParameters = tableValueParameters.Cast<object>().ToArray();
            }
            else
            {
                for (int i = 0; i < addParameters.Count(); i++)
                {
                    spSignature.AppendFormat(" @{0}", addParameters[i].ParameterName);
                    if (i != length) spSignature.Append(",");
                }
                spParameters = _parameters.Cast<object>().ToArray();
            }

            return spParameters;
        }

        public ObjectResult ExecuteStoredProcedure()
        {
            var spSignature = new StringBuilder();
            spSignature.AppendFormat("EXECUTE {0}", StoredProcedure);
            var spParameters = GetParameters(spSignature);
            ObjectResult objectResult = new ObjectResult() { ErrorCod = 0, Message = "Sucesso" };
            var sbMsgErr = new StringBuilder();
            try
            {
                objectResult.Result = _contexto.Database.ExecuteSqlCommand(spSignature.ToString(), spParameters);
            }
            catch (ValidationException exc)
            {
                sbMsgErr.Append($"{nameof(SaveChanges)} validation exception: {exc?.Message}");
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    if (ex.InnerException != null)
                    {
                        objectResult.ErrorCod = ((SqlException)ex.InnerException).Number;

                        switch (objectResult.Result)
                        {
                            case 2627:
                                sbMsgErr.Append($"{nameof(SaveChanges)} validation exception Unique constraint error");
                                break;
                            case 547:
                                sbMsgErr.Append($"{nameof(SaveChanges)} validation exception Constraint check violation");
                                break;
                            case 2601:
                                sbMsgErr.Append($"{nameof(SaveChanges)} validation exception Duplicated key row error");
                                break;
                            case 229:
                                sbMsgErr.Append($"{nameof(SaveChanges)} The UPDATE permission was denied on the object");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        objectResult.ErrorCod = ((SqlException)ex).Number;
                        sbMsgErr.Append($"{nameof(SaveChanges)} Message: {((SqlException)ex).Message}");
                    }
                }

                objectResult.Message = sbMsgErr.ToString();
                return objectResult;

            }

            return objectResult;
        }

        public void Dispose()
        {
            _contexto.Dispose();
            _parameters?.Clear();
            GC.SuppressFinalize(this);
        }
    }
}