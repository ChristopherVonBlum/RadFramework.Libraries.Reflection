using System;
using System.Collections.Concurrent;

namespace RadFramework.Libraries.Reflection.Caching
{
    public class CachedMetadataBase<TMetadata>
    {
        public TMetadata InnerMetaData { get; internal set; }
    
        private ConcurrentDictionary<int, object> queryCache = new ConcurrentDictionary<int, object>();

        public TResult Query<TResult>(Func<TMetadata, TResult> query)
        {
            return (TResult) queryCache.GetOrAdd(query.Method.MetadataToken, (i) => query(InnerMetaData));
        }
    }
}