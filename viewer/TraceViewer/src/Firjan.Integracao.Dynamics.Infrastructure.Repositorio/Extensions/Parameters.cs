using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions
{
    public static class Parameters
    {
        public static bool TryToInt32(object value, out int result)
        {
            if (value == null)
            {
                result = 0;
                return false;
            }
            var typeConverter = System.ComponentModel.TypeDescriptor.GetConverter(value);
            if (typeConverter != null && typeConverter.CanConvertTo(typeof(int)))
            {
                var convertTo = typeConverter.ConvertTo(value, typeof(int));
                if (convertTo != null)
                {
                    result = (int)convertTo;
                    return true;
                }
            }
            return int.TryParse(value.ToString(), out result);
        }

        public static object GetDBNullOrValue<T>(this T val)
        {
            bool isDbNull = true;
            Type t = typeof(T);

            if (Nullable.GetUnderlyingType(t) != null)
                isDbNull = EqualityComparer<T>.Default.Equals(default(T), val);
            else if (t.IsValueType)
                isDbNull = false;
            else
                isDbNull = val == null;          

            return isDbNull ? DBNull.Value : (object)val;
        }

        public static object ConvertEnumTo<T>(this object val)
        {
            bool isDbNull = true;
            Type t = typeof(T);

            if (t != null) {

                var s = val.ToString();
                if (t == typeof(char))
                    return Convert.ToChar(s);
                if (t == typeof(int))
                    return Convert.ToInt32(s);
                if (t == typeof(Int64))
                    return Convert.ToInt64(s);
                if (t == typeof(string))
                    return Convert.ToString(s);
                if (t == typeof(Double))
                    return Convert.ToDouble(s);
                if (t == typeof(byte))
                    return Convert.ToByte(s);
            }
            else if (t.IsValueType)
                isDbNull = false;
            else
                isDbNull = val == null;

            return isDbNull ? DBNull.Value : (object)val;
        }

        public static string ExpressionValue<T>(this Expression<Func<T, bool>> expression)
        {
            return Expression.Lambda(((BinaryExpression)expression.Body).Right).Compile().DynamicInvoke() as string;
        }

        public static bool TryCast<T>(this object obj, out T result) where T : struct
        {
            if (obj is T)
            {
                result = (T)obj;
                return true;
            }

            result = default(T);
            return false;
        }
    }

    public class ExpressionEqualityComparer : IEqualityComparer<Expression>
    {
        public bool Equals(Expression x, Expression y)
        {
            return EqualsRecursive(x, y);
        }

        private bool EqualsRecursive(Expression x, Expression y)
        {
            if (x == null || y == null) return false;

            if (object.ReferenceEquals(x, y))
                return true;

            if (x.GetType() != y.GetType() ||
                x.Type != y.Type ||
                x.NodeType != y.NodeType)
            {
                return false;
            }

            LambdaExpression lambdaExpressionX = x as LambdaExpression;
            LambdaExpression lambdaExpressionY = y as LambdaExpression;

            if (lambdaExpressionX != null && lambdaExpressionY != null)
            {
                return AreAllArgumentsEqual(lambdaExpressionX.Parameters, lambdaExpressionY.Parameters) &&
                    Equals(lambdaExpressionX.Body, lambdaExpressionY.Body);
            }

            BinaryExpression binaryExpressionX = x as BinaryExpression;
            BinaryExpression binaryExpressionY = y as BinaryExpression;

            if (binaryExpressionX != null && binaryExpressionY != null)
            {
                return binaryExpressionX.Method == binaryExpressionY.Method &&
                    Equals(binaryExpressionX.Left, binaryExpressionY.Left) &&
                    Equals(binaryExpressionX.Right, binaryExpressionY.Right);
            }

            UnaryExpression unaryExpressionX = x as UnaryExpression;
            UnaryExpression unaryExpressionY = y as UnaryExpression;

            if (unaryExpressionX != null && unaryExpressionY != null)
            {
                return unaryExpressionX.Method == unaryExpressionY.Method &&
                    Equals(unaryExpressionX.Operand, unaryExpressionY.Operand);
            }

            MethodCallExpression methodCallExpressionX = x as MethodCallExpression;
            MethodCallExpression methodCallExpressionY = y as MethodCallExpression;

            if (methodCallExpressionX != null && methodCallExpressionY != null)
            {
                return AreAllArgumentsEqual(methodCallExpressionX.Arguments, methodCallExpressionY.Arguments) &&
                    methodCallExpressionX.Method == methodCallExpressionY.Method &&
                    Equals(methodCallExpressionX.Object, methodCallExpressionY.Object);
            }

            ConditionalExpression conditionalExpressionX = x as ConditionalExpression;
            ConditionalExpression conditionalExpressionY = y as ConditionalExpression;

            if (conditionalExpressionX != null && conditionalExpressionY != null)
            {
                return Equals(conditionalExpressionX.Test, conditionalExpressionY.Test) &&
                    Equals(conditionalExpressionX.IfTrue, conditionalExpressionY.IfTrue) &&
                    Equals(conditionalExpressionX.IfFalse, conditionalExpressionY.IfFalse);
            }

            InvocationExpression invocationExpressionX = x as InvocationExpression;
            InvocationExpression invocationExpressionY = y as InvocationExpression;

            if (invocationExpressionX != null && invocationExpressionY != null)
            {
                return AreAllArgumentsEqual(invocationExpressionX.Arguments, invocationExpressionY.Arguments) &&
                    Equals(invocationExpressionX.Expression, invocationExpressionY.Expression);
            }

            MemberExpression memberExpressionX = x as MemberExpression;
            MemberExpression memberExpressionY = y as MemberExpression;

            if (memberExpressionX != null && memberExpressionY != null)
            {
                return memberExpressionX.Member == memberExpressionY.Member &&
                    Equals(memberExpressionX.Expression, memberExpressionY.Expression);
            }

            ConstantExpression constantExpressionX = x as ConstantExpression;
            ConstantExpression constantExpressionY = y as ConstantExpression;

            if (constantExpressionX != null && constantExpressionY != null)
            {
                return constantExpressionX.Value.Equals(constantExpressionY.Value);
            }

            ParameterExpression parameterExpressionX = x as ParameterExpression;
            ParameterExpression parameterExpressionY = y as ParameterExpression;

            if (parameterExpressionX != null && parameterExpressionY != null)
            {
                return parameterExpressionX.Name == parameterExpressionY.Name;
            }

            NewExpression newExpressionX = x as NewExpression;
            NewExpression newExpressionY = y as NewExpression;

            if (newExpressionX != null && newExpressionY != null)
            {
                return AreAllArgumentsEqual(newExpressionX.Arguments, newExpressionY.Arguments) &&
                    newExpressionX.Constructor == newExpressionY.Constructor;
            }

           return false;
        }

        private bool AreAllArgumentsEqual<T>(IEnumerable<T> xArguments, IEnumerable<T> yArguments)
            where T : Expression
        {
            var argumentEnumeratorX = xArguments.GetEnumerator();
            var argumentEnumeratorY = yArguments.GetEnumerator();

            bool haveNotEnumeratedAllOfX = argumentEnumeratorX.MoveNext();
            bool haveNotEnumeratedAllOfY = argumentEnumeratorY.MoveNext();

            bool areAllArgumentsEqual = true;
            while (haveNotEnumeratedAllOfX && haveNotEnumeratedAllOfY && areAllArgumentsEqual)
            {
                areAllArgumentsEqual = Equals(argumentEnumeratorX.Current, argumentEnumeratorY.Current);
                haveNotEnumeratedAllOfX = argumentEnumeratorX.MoveNext();
                haveNotEnumeratedAllOfY = argumentEnumeratorY.MoveNext();
            }

            if (haveNotEnumeratedAllOfX || haveNotEnumeratedAllOfY)
            {
                return false;
            }

            return areAllArgumentsEqual;
        }

        public int GetHashCode(Expression x)
        {
            LambdaExpression lambdaExpressionX = x as LambdaExpression;

            if (lambdaExpressionX != null)
            {
                return XorHashCodes(lambdaExpressionX.Parameters) ^
                    GetHashCode(lambdaExpressionX.Body);
            }

            BinaryExpression binaryExpressionX = x as BinaryExpression;

            if (binaryExpressionX != null)
            {
                int methodHashCode = binaryExpressionX.Method != null ? binaryExpressionX.Method.GetHashCode() : binaryExpressionX.NodeType.GetHashCode();
                return methodHashCode ^
                    GetHashCode(binaryExpressionX.Left) ^
                    GetHashCode(binaryExpressionX.Right);
            }

            UnaryExpression unaryExpressionX = x as UnaryExpression;

            if (unaryExpressionX != null)
            {
                int methodHashCode = unaryExpressionX.Method != null ? unaryExpressionX.Method.GetHashCode() : unaryExpressionX.NodeType.GetHashCode();
                return methodHashCode ^
                    GetHashCode(unaryExpressionX.Operand);
            }

            MethodCallExpression methodCallExpressionX = x as MethodCallExpression;

            if (methodCallExpressionX != null)
            {
                return XorHashCodes(methodCallExpressionX.Arguments) ^
                    methodCallExpressionX.Method.GetHashCode() ^
                    GetHashCode(methodCallExpressionX.Object);
            }

            ConditionalExpression conditionalExpressionX = x as ConditionalExpression;

            if (conditionalExpressionX != null)
            {
                return
                    GetHashCode(conditionalExpressionX.Test) ^
                    GetHashCode(conditionalExpressionX.IfTrue) ^
                    GetHashCode(conditionalExpressionX.IfFalse);
            }

            InvocationExpression invocationExpressionX = x as InvocationExpression;

            if (invocationExpressionX != null)
            {
                return
                    XorHashCodes(invocationExpressionX.Arguments) ^
                    GetHashCode(invocationExpressionX.Expression);
            }

            MemberExpression memberExpressionX = x as MemberExpression;

            if (memberExpressionX != null)
            {
                return
                    memberExpressionX.Member.GetHashCode() ^
                    GetHashCode(memberExpressionX.Expression);
            }

            ConstantExpression constantExpressionX = x as ConstantExpression;

            if (constantExpressionX != null)
            {
                int valueHash = constantExpressionX.Value != null ? constantExpressionX.Value.GetHashCode() : constantExpressionX.GetHashCode();
                return valueHash;
            }

            NewExpression newExpressionX = x as NewExpression;

            if (newExpressionX != null)
            {

                return
                    XorHashCodes(newExpressionX.Arguments) ^
                    newExpressionX.Constructor.GetHashCode();
            }

            return 0;
        }

        private int XorHashCodes<T>(IEnumerable<T> expressions)
            where T : Expression
        {
            int accumulatedHashCode = 0;
            foreach (var expression in expressions)
            {
                accumulatedHashCode ^= GetHashCode(expression);
            }

            return accumulatedHashCode;
        }
    }
}
