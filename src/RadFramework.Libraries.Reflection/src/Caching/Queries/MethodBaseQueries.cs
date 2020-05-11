using System.Reflection;

namespace RadFramework.Libraries.Reflection.Caching.Queries
{
    public class MethodBaseQueries
    {
        public static ParameterInfo[] GetParameters(MethodBase methodBase)
        {
            return methodBase.GetParameters();
        }
    }
}