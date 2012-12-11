using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using Ninject.Extension.AspNetCache;

namespace Ninject.Extension.AspNetCache
{
	public class ServiceDataCache : CacheManager
	{
        public ServiceDataCache(double defaultTimeoutMinutes)
        {
            TimeoutMinutes = defaultTimeoutMinutes;
        }
	}
}
