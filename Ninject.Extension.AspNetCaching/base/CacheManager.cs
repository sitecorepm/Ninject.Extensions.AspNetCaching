using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Ninject.Extension.AspNetCache
{
    public abstract class CacheManager : ICacheManager
    {
        private static KeyLockManager _lockMgr = new KeyLockManager();

        public CacheManager()
        {
            TimeoutMinutes = 60;
            Dependency = null;
            ItemPriority = CacheItemPriority.Default;
            ItemRemovedCallback = null;
        }

        public double TimeoutMinutes { get; set; }
        public CacheDependency Dependency { get; set; }
        public CacheItemPriority ItemPriority { get; set; }
        public CacheItemRemovedCallback ItemRemovedCallback { get; set; }

        public void Add(object cacheObject, string key)
        {
            this.Add(cacheObject, key, this.TimeoutMinutes);
        }
        private void Add(object cacheObject, string key, double minutes)
        {
            HttpContext.Current.Cache.Insert(key, cacheObject,
                                    this.Dependency,
                                    DateTime.UtcNow.AddMinutes(minutes),
                                    System.Web.Caching.Cache.NoSlidingExpiration,
                                    this.ItemPriority,
                                    this.ItemRemovedCallback);
        }

        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public bool Exist(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }

        public virtual T Get<T>(string key) where T : class
        {
            return HttpContext.Current.Cache[key] as T;
        }

        public virtual T Get<T>(string key, Func<T> fn) where T : class
        {
            return this.Get<T>(key, this.TimeoutMinutes, fn);
        }
        public virtual T Get<T>(string key, double timeoutminutes, Func<T> fn) where T : class
        {
            var obj = this.Get<T>(key);
            if (obj == default(T))
            {
                lock (_lockMgr.AcquireKeyLock(key))
                {
                    // Re-check for object since we might have been blocked by the lock
                    obj = this.Get<T>(key);
                    if (obj == default(T))
                    {
                        obj = fn();
                        this.Add(obj, key, timeoutminutes);
                    }
                }
            }

            return obj;
        }
    }
}
