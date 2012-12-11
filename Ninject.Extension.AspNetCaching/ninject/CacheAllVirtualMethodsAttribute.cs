using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Request;
using Ninject.Extensions.Interception.Attributes;

namespace Ninject.Extension.AspNetCache
{
    public class CacheAllVirtualMethodsAttribute : InterceptAttribute
    {
        public int DefaultTimeoutMinutes { get; set; }
         
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            var interceptor = request.Kernel.Get<CacheInterceptor>();

            if (DefaultTimeoutMinutes != 0)
                interceptor.Timeout = TimeSpan.FromMinutes(DefaultTimeoutMinutes);

            interceptor.CacheKeyPrefix = request.Target.GetType().FullName;

            return interceptor;
        }
    }
}
