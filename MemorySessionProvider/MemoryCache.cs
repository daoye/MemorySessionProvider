using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace MemorySessionProvider
{
    /// <summary>
    /// Memory data store helper.
    /// </summary>
    public static class MemoryCache
    {
        /// <summary>
        /// Add data to cache.
        /// </summary>
        /// <param name="key">The cache key</param>
        /// <param name="value">The value</param>
        /// <param name="expries">Expreis date</param>
        public static void Set(string key, SessionData value, DateTime expries)
        {
            HttpRuntime.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);
        }

        /// <summary>
        /// Get cache data.
        /// </summary>
        /// <param name="key">The cache key</param>
        /// <returns></returns>
        public static SessionData Get(string key)
        {
            SessionData data = null;
            object result = HttpRuntime.Cache.Get(key);

            if (null != result)
            {
                data = result as SessionData;
                if (data.Expries < DateTime.Now)
                {
                    Remove(key);
                    data = null;
                }
            }

            return data;
        }

        /// <summary>
        /// Remove cache data.
        /// </summary>
        /// <param name="key">The cache key</param>
        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}
