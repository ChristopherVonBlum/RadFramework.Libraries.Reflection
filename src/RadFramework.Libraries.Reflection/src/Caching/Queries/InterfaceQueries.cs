using System;
using System.Linq;
using System.Reflection;

namespace RadFramework.Libraries.Reflection.Caching.Queries
{
    public static class InterfaceQueries
    {
        public static PropertyInfo[] GetProperties(Type type) => type.GetProperties();
        public static EventInfo[] GetEvents(Type type) => type.GetEvents();

        public static MethodInfo[] GetMethods(Type type) =>
            type
                .GetMethods()
                .Where(method => !method.IsSpecialName)
                .ToArray();

        public static Type[] GetBaseInterfaces (Type type) => type.GetInterfaces();
    }
}