using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions
{
    public static class QueryExtensions
    {
        public static async Task<T> FirstOrDefaultAsync<T>(this Task<IEnumerable<T>> task)
        {
            return (await task).FirstOrDefault();
        }

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string ordering, bool ascending = true)
        {
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "p");
            PropertyInfo property;
            Expression propertyAccess;
            if (ordering.Contains("."))
            {
                String[] childProperties = ordering.Split(".");
                property = type.GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(TEntity).GetProperty(ordering);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }

            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending", new[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<TEntity>(resultExp);
        }        
    }
}

