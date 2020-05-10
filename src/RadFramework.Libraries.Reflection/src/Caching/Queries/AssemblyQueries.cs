using System;
using System.Linq;
using System.Reflection;

namespace RadFramework.Libraries.Reflection.Caching.Queries
{
    public class AssemblyQueries
    {
        public static Type[] GetTypes(Assembly assembly)
        {
            return assembly.GetTypes();
        }
        public static CachedType[] GetCachedTypes(Assembly assembly)
        {
            return assembly.GetTypes().Select(type => (CachedType)type).ToArray();
        }
    }
}