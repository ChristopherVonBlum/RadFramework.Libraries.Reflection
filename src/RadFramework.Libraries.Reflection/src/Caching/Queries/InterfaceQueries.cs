using System;
using System.Linq;
using System.Reflection;

namespace RadFramework.Libraries.Reflection.Caching.Queries
{
    public static class InterfaceQueries
    {
        public static Func<Type, PropertyInfo[]> GetProperties = (type) => type.GetProperties();
        public static Func<Type, EventInfo[]> GetEvents = (type) => type.GetEvents();

        public static Func<Type, MethodInfo[]> GetMethods = (type)
            => type
                .GetMethods()
                .Where(method => !method.IsSpecialName)
                .ToArray();

        public static Func<Type, Type[]> GetBaseInterfaces = (type) => type.GetInterfaces();
    }
}