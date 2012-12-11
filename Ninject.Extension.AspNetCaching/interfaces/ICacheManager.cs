using System;
using System.Web.Caching;
namespace Ninject.Extension.AspNetCache
{
    public interface ICacheManager
    {
        double TimeoutMinutes { get; set; }
        CacheDependency Dependency { get; set; }
        CacheItemPriority ItemPriority { get; set; }
        CacheItemRemovedCallback ItemRemovedCallback { get; set; }

        bool Exist(string key);
        void Remove(string key);
        void Add(object cacheObject, string keyName);
        T Get<T>(string key) where T : class;
        T Get<T>(string key, Func<T> fn) where T : class;
        T Get<T>(string key, double timeoutminutes, Func<T> fn) where T : class;
    }
}
