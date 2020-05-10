using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RadFramework.Libraries.Reflection.Caching.Queries
{
    public static class ClassQueries
    {
        public static Func<Type, IEnumerable<ConstructorInfo>> GetPublicConstructors => type =>
            type
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        public static Func<Type, ConstructorInfo> GetPublicEmptyConstructor => type =>
            type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public,
                null,
                CallingConventions.Standard,
                new Type[0],
                null);

        public static Func<Type, IEnumerable<CachedFieldInfo>> GetPublicFields => type =>
            Enumerable.Where(type
                .GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Select(ReflectionCache.CurrentCache.GetCachedMetaData), field => !field.Query(AttributeLocationQueries.GetAttributes).OfType<CompilerGeneratedAttribute>().Any());

        public static Func<Type, IEnumerable<EventInfo>> GetPublicImplementedEvents => type =>
            type
                .GetEvents(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        public static Func<Type, IEnumerable<Type>> GetPublicImplementedInterfaces => type =>
            type.GetInterfaces();

        public static Func<Type, IEnumerable<MethodInfo>> GetPublicImplementedMethods => type =>
            type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(method => !method.IsSpecialName);

        public static Func<Type, IEnumerable<PropertyInfo>> GetPublicImplementedProperties => type =>
            type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

        public static Func<Type, IEnumerable<CachedMethodInfo>> GetPublicStaticMethods => type =>
            type
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Select(info => ReflectionCache.CurrentCache.GetCachedMetaData(info))
                .Where(method => !method.Query(AttributeLocationQueries.GetAttributes).OfType<CompilerGeneratedAttribute>().Any())
                .ToImmutableList();

        public static Func<Type, IEnumerable<Type>> GetTypeArguments => type =>
                                                                        {
                                                                            if (type.IsGenericType || type.IsGenericTypeDefinition)
                                                                            {
                                                                                return type.GetGenericArguments();
                                                                            }

                                                                            return new Type[0];
                                                                        };

        public static Func<Type, Type> GetGenericTypeDefinition => type =>
                                                                   {
                                                                       if (type.IsGenericTypeDefinition)
                                                                       {
                                                                           return type;
                                                                       }

                                                                       if (type.IsGenericType)
                                                                       {
                                                                           return type.GetGenericTypeDefinition();
                                                                       }

                                                                       return null;
                                                                   };

        public static Func<Type, ConstructorInfo> GetDefaultConstructor => type =>
                                                                               type.GetConstructor(
                                                                                   BindingFlags.Instance | BindingFlags.Public,
                                                                                   null,
                                                                                   CallingConventions.Standard,
                                                                                   new Type[0],
                                                                                   null);

        public static Type[] GetGenericArguments(Type type)
        {
            return type.GetGenericArguments();
        }
    }
}