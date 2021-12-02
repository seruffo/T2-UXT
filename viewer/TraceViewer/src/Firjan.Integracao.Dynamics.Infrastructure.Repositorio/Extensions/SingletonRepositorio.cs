using System;
using System.Reflection;

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions
{
    public static class SingletonRepositorio<T> where T : class , new()
    {
        static readonly string MethodInitialized = "Initialized";
        static readonly Lazy<T> instanceHolder = new Lazy<T>(() => new T());
        public static T Instance
        {
            get { return instanceHolder.Value; }
        }

        public static T Create(object context)
        {
            var type = Instance.GetType();
            MethodInfo methodInfo = type.GetMethod(MethodInitialized);
            methodInfo.Invoke(Instance, new object[] { context } );
            return Instance;
        }
    }
}
