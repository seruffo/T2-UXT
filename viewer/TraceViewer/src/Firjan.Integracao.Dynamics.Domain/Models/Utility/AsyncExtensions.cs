using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Firjan.Integracao.Dynamics.Domain.Models.Utility
{
    public static class GenericExtension
    {
        public static Nullable<T> ToNullable<T>(this object input)
        where T : struct
        {
            if (input == null)
                return null;
            if (input is Nullable<T> || input is T)
                return (Nullable<T>)input;
            throw new InvalidCastException();
        }

        public static T? GetValueOrNull<T>(this string valueAsString)  where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
                return null;
            return (T)Convert.ChangeType(valueAsString, typeof(T));
        }

        public static Nullable<T> ToNullable<T>(this string s) where T : struct
        {
            Nullable<T> result = new Nullable<T>();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)conv.ConvertFrom(s);
                }
            }
            catch { }
            return result;
        }
    }

    public static class ForEachAsyncExtension
    {
        public static Task ForEachAsync<T>(this IEnumerable<T> source, int dop, Func<T, Task> body)
        {
            return Task.WhenAll(
                    from partition in Partitioner.Create(source).GetPartitions(dop)
                    select Task.Run(async delegate
                    {
                        using (partition)
                            while (partition.MoveNext())
                                await body(partition.Current).ConfigureAwait(false);
                    })
                  );
        }
    }
}
