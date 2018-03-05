using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace SChat.Models.CacheRepository
{
    public class GlobalCache
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;

        private GlobalCache() { }
        public static MemoryCache getIstance() {
            return Cache;
        }
    }
}