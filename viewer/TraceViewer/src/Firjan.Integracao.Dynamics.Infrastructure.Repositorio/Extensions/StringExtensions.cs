using System;
using System.Reflection;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions
{
    public static class Extensions
    {
        /// <summary>
        ///     A string extension method that query if '@this' is empty.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if empty, false if not.</returns>
        public static bool IsNullOrEmpty(this string testString)
        {
            return string.IsNullOrEmpty(testString);
        }
    }

    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }

    public static class ObjectValue
    {
        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            return (T)retval;
        }
    }
}