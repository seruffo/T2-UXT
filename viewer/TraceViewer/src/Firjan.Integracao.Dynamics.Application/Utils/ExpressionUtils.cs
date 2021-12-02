using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Application.Utils
{
    public static class IEnumerableExtensions
    {
        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> funcBody, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    { await funcBody(partition.Current); }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(p => AwaitPartition(p)));
        }

        public static Task ParallelForEachAsync<T1, T2>(this IEnumerable<T1> source, Func<T1, T2, Task> funcBody, T2 inputClass, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T1> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    { await funcBody(partition.Current, inputClass); }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(p => AwaitPartition(p)));
        }

        public static Task ParallelForEachAsync<T1, T2, T3>(this IEnumerable<T1> source, Func<T1, T2, T3, Task> funcBody, T2 inputClass, T3 secondInputClass, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T1> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    { await funcBody(partition.Current, inputClass, secondInputClass); }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(p => AwaitPartition(p)));
        }

        public static Task ParallelForEachAsync<T1, T2, T3, T4>(this IEnumerable<T1> source, Func<T1, T2, T3, T4, Task> funcBody, T2 inputClass, T3 secondInputClass, T4 thirdInputClass, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T1> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    { await funcBody(partition.Current, inputClass, secondInputClass, thirdInputClass); }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(p => AwaitPartition(p)));
        }
    }

    public class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }

    public static class CombineFunction
    {
        public static Expression<Func<T, bool>> Combine<T>(this Expression<Func<T, bool>> filter1, Expression<Func<T, bool>> filter2)
        {
            filter1 = filter1.IsNull();
            var rewrittenBody1 = new ReplaceVisitor(
                filter1.Parameters[0], filter2.Parameters[0]).Visit(filter1.Body);
            var newFilter = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(rewrittenBody1, filter2.Body), filter2.Parameters);
            return newFilter;
        }
    }

    public static class AreEq
    {
        public static bool AreEqual<T>(T param1, T param2)
        {
            return EqualityComparer<T>.Default.Equals(param1, param2);
        }
    }

    public static class IfNotNullExtensionMethod
    {
        public static U IfNotNull<T, U>(this T t, Func<T, U> fn)
        {
            return t != null ? fn(t) : default;
        }
    }

    internal class SubstExpressionVisitor : System.Linq.Expressions.ExpressionVisitor
    {
        public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (subst.TryGetValue(node, out Expression newValue))
            {
                return newValue;
            }
            return node;
        }
    }

    public static class Extensions
    {
        public static Expression<Func<T, bool>> ToExpression<T>(this Predicate<T> p)
        {
            ParameterExpression p0 = Expression.Parameter(typeof(T));
            return Expression.Lambda<Func<T, bool>>(Expression.Call(p.Method, p0),
                  new ParameterExpression[] { p0 });
        }
    }

    public static class IQueryableExtensions
    {
        public static Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageSize, int pageIndex = 1)
        {
            var count = source.Count();
            return
                source.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .AsAsyncEnumerable()
                .Aggregate(new PaginatedList<T>(
                    totalCount: count,
                    pageSize: pageSize,
                    pageIndex: pageIndex), (list, x) => { list.Add(x); return list; });
        }

    }

    public class PaginatedList<T> : List<T>
    {
        private int pageIndex;
        private int pageSize;
        public PaginatedList(IEnumerable<T> collection, int totalCount, int pageSize, int pageIndex) : base(collection)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        public PaginatedList(int totalCount, int pageSize, int pageIndex) : base()
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        public PaginatedList(int capacity, int totalCount, int pageSize, int pageIndex) : base(capacity)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        public int PageIndex
        {
            get { return pageIndex; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(PageIndex));
                pageIndex = value;
            }
        }

        public int PageSize
        {
            get { return pageSize; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(PageSize));
                pageSize = value;
            }
        }

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public int TotalCount { get; }
    }

    public static class Filter
    {
        public static Expression<Func<T, bool>> BuildStringCompareLambda<T>(
            MemberExpression property,
            ConstantExpression value,
            ParameterExpression parameter)
        {
            var equalsMethod = typeof(string).GetMethod("Equals",
                    new[] { typeof(string), typeof(string) });
            var comparison = Expression.Call(equalsMethod, property, value);
            return Expression.Lambda<Func<T, bool>>(comparison, parameter);
        }

        public static Expression<Func<T, bool>> BuildNullableCompareLambda<T>(MemberExpression property,
            ConstantExpression value,
            ParameterExpression parameter)
        {
            var underlyingType = Nullable.GetUnderlyingType(property.Type);

            if (underlyingType == typeof(int) || underlyingType == typeof(Int16) || underlyingType == typeof(Int32) ||
                underlyingType == typeof(Int64) || underlyingType == typeof(UInt16) || underlyingType == typeof(UInt32) ||
                underlyingType == typeof(UInt64))
            {
                var equalsMethod = underlyingType.GetMethod("Equals", new[] { underlyingType });

                var left = Expression.Convert(property, underlyingType);
                var right = Expression.Convert(value, underlyingType);

                var comparison = Expression.Call(left, equalsMethod, new Expression[] { right });

                return Expression.Lambda<Func<T, bool>>(comparison, parameter);
            }

            return null;
        }

        public static Expression<Func<T, bool>> BuildCompareLambda<T>(
                MemberExpression property,
                ConstantExpression value,
                ParameterExpression parameter)
        {
            Expression<Func<T, bool>> lambda = null;
            if (property.Type == typeof(string))
                lambda = BuildStringCompareLambda<T>(property, value, parameter);
            else if (property.Type.IsGenericType && Nullable.GetUnderlyingType(property.Type) != null)
                lambda = BuildNullableCompareLambda<T>(property, value, parameter);

            if (lambda == null)
                throw new Exception(String.Format("SelectrionCriteria cannot handle property type '{0}'", property.Type.Name));

            return lambda;
        }

        public static async Task<IEnumerable<T>> Where<T>( this IEnumerable<T> source, Func<T, Task<bool>> predicate)
        {
            var results = new ConcurrentQueue<T>();
            var tasks = source.Select(
                async x =>
                {
                    if (await predicate(x))
                        results.Enqueue(x);
                });
            await Task.WhenAll(tasks);
            return results;
        }

        public static async Task<T[]> FilterAsync<T>(IEnumerable<T> sourceEnumerable, Func<T, Task<bool>> predicateAsync)
        {
            return (await Task.WhenAll(
                sourceEnumerable.Select(
                    v => predicateAsync(v)
                    .ContinueWith(task => new { Predicate = task.Result, Value = v })))
                ).Where(a => a.Predicate).Select(a => a.Value).ToArray();
        }

        public static async Task<IEnumerable<TIn>> FilterAsyncTIn<TIn>(this IEnumerable<TIn> source, Func<TIn, Task<bool>> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var result = new List<TIn>();
            foreach (var item in source)
            {
                if (await action(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }

    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> IsNull<T>(this Expression<Func<T, bool>> source)
        {
            Expression<Func<T, bool>> expression = c => 1 == 1;
            if (source == null)
            {
                source = expression;
                return expression;
            }
            else
                return source;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {
            if (a == null)
                a = b;

            ParameterExpression p = a.Parameters[0];
            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }
    }

    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> EqualToExpression<T, TValue>(Expression<Func<T, bool>> selectValue, TValue targetValue)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    selectValue.Body,
                    Expression.Constant(targetValue)),
                selectValue.Parameters);
        }

        public static Expression<Func<T, bool>> AddContains<T>(this LambdaExpression selector, string value)
        {
            var mi = typeof(string).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Length == 1);

            var body = selector.GetBody().AsString();

            var x = Expression.Call(body, mi, Expression.Constant(value));

            LambdaExpression e = Expression.Lambda(x, selector.Parameters.ToArray());
            return (Expression<Func<T, bool>>)e;
        }

        public static Expression GetBody(this LambdaExpression expression)
        {
            Expression body;
            if (expression.Body is UnaryExpression)
                body = ((UnaryExpression)expression.Body).Operand;
            else
                body = expression.Body;

            return body;
        }

        public static Expression AsString(this Expression expression)
        {
            if (expression.Type == typeof(string))
                return expression;
            MethodInfo toString = typeof(SqlServerDbFunctionsExtensions).GetMethods().First(m => Query(m));
            var cast = Expression.Convert(expression, typeof(double?));
            return Expression.Call(toString, cast);
        }

        private static bool Query(MethodInfo m)
        {
            return m.Name == "StringConvert" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(double?);
        }
    }

    public static class ExpressionUtils
    {
        public static Expression<Func<TTo, bool>> ConvertExpression<TFrom, TTo>(this Expression<Func<TFrom, bool>> expr)
        {
            if (expr == null) return null;
            Dictionary<Expression, Expression> substitutues = new Dictionary<Expression, Expression>();
            var oldParam = expr.Parameters[0];
            var newParam = Expression.Parameter(typeof(TTo), oldParam.Name);
            substitutues.Add(oldParam, newParam);
            Expression body = ConvertNode(expr.Body, substitutues);
            return Expression.Lambda<Func<TTo, bool>>(body, newParam);
        }

        static Expression ConvertNode(Expression node, IDictionary<Expression, Expression> subst)
        {
            if (node == null) return null;
            if (subst.ContainsKey(node)) return subst[node];

            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return node;
                case ExpressionType.MemberAccess:
                    {
                        var me = (MemberExpression)node;
                        var newNode = ConvertNode(me.Expression, subst);

                        MemberInfo info = null;
                        foreach (MemberInfo mi in newNode.Type.GetMembers())
                        {
                            if ((mi.MemberType == MemberTypes.Property || mi.MemberType == MemberTypes.Field) &&
                                me.Member.Name.ToLower() == mi.Name.ToLower())
                            {
                                info = mi;
                                break;
                            }
                        }
                        return Expression.MakeMemberAccess(newNode, info);
                    }
                case ExpressionType.OrElse:
                    {
                        var be = (BinaryExpression)node;

                        return Expression.OrElse(ConvertNode(be.Left, subst), ConvertNode(be.Right, subst));

                    }
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                    {
                        var be = (BinaryExpression)node;

                        return Expression.GreaterThan(ConvertNode(be.Left, subst), ConvertNode(be.Right, subst));
                    }
                case ExpressionType.Coalesce:
                    {
                        var be = (BinaryExpression)node;

                        return Expression.Coalesce(ConvertNode(be.Left, subst), ConvertNode(be.Right, subst));
                    }
                case ExpressionType.GreaterThanOrEqual:
                    {
                        var be = (BinaryExpression)node;

                        return Expression.GreaterThanOrEqual(ConvertNode(be.Left, subst), ConvertNode(be.Right, subst));
                    }
                case ExpressionType.Conditional:
                    {
                        ConditionalExpression co = (ConditionalExpression)node;
                        var expressionIfFalse = ((ConditionalExpression)co).IfFalse;
                        var expressionIfTrue = ((ConditionalExpression)co).IfTrue;
                        return Expression.Condition(co.Test, expressionIfTrue, expressionIfFalse);
                    }
                case ExpressionType.AndAlso:
                    {
                        var be = (BinaryExpression)node;

                        return Expression.AndAlso(ConvertNode(be.Left, subst), ConvertNode(be.Right, subst));
                    }
                case ExpressionType.NotEqual:
                    {
                        var be = (BinaryExpression)node;

                        return Expression.NotEqual(ConvertNode(be.Left, subst), ConvertNode(be.Right, subst));
                    }
                case ExpressionType.Call:
                    {
                        var me = (MethodCallExpression)node;

                        return Expression.Call(node, me.Method, me.Arguments);
                    }
                case ExpressionType.Convert:
                    {
                        return UnaryExpression(node,subst);
                    }
                case ExpressionType.Not:
                    {
                        return Expression.Not(node);
                    }
                case ExpressionType.Equal:
                    {
                        return MakeBinary(node, subst);
                    }

                default:
                    throw new NotSupportedException(node.NodeType.ToString());
            }
        }

        public static bool IsIn<T>(this T keyObject, params T[] collection)
        {
            return collection.Contains(keyObject);
        }

        public static bool IsIn<T>(this T keyObject, IEnumerable<T> collection)
        {
            return collection.Contains(keyObject);
        }

        public static bool IsNotIn<T>(this T keyObject, params T[] collection)
        {
            return keyObject.IsIn(collection) == false;
        }

        public static bool IsNotIn<T>(this T keyObject, IEnumerable<T> collection)
        {
            return keyObject.IsIn(collection) == false;
        }

        private static UnaryExpression UnaryExpression(Expression node, IDictionary<Expression, Expression> subst)
        {
            UnaryExpression unExp = (UnaryExpression)node;
            Expression operand = ConvertNode(unExp.Operand, subst);
            return operand == null ? null : Expression.MakeUnary(unExp.NodeType, operand,
                unExp.Type, unExp.Method);
        }

        private static Expression MakeBinary(Expression node, IDictionary<Expression, Expression> subst)
        {
            var be = (BinaryExpression)node;

            return Expression.MakeBinary(be.NodeType, ConvertNode(be.Left, subst), ConvertNode(be.Right, subst), be.IsLiftedToNull, be.Method);
        }
    }
}
