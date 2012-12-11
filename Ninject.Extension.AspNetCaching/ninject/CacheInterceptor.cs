using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Request;

namespace Ninject.Extension.AspNetCache
{
    public class CacheInterceptor : IInterceptor
    {
        [Inject]
        public ICacheManager Cache { get; set; }

        public TimeSpan? Timeout { get; set; }

        public string CacheKeyPrefix { get; set; }

        public void Intercept(IInvocation invocation)
        {
            double minutes = Cache.TimeoutMinutes;
            if (Timeout.HasValue)
                minutes = Timeout.Value.TotalMinutes;

            var methodTimeouts = invocation.Request.Method.GetCustomAttributes(typeof(CacheTimeoutAttribute), false);
            if (methodTimeouts.Length > 0)
            {
                minutes = ((CacheTimeoutAttribute)methodTimeouts.First()).TimeoutMinutes;
            }

            invocation.ReturnValue = Cache.Get(GenerateCacheKey(invocation.Request), minutes, delegate()
            {
                invocation.Proceed();
                return invocation.ReturnValue;
            });
        }

        private string GenerateCacheKey(IProxyRequest request)
        {
            var sb = new StringBuilder();

            sb.Append(this.CacheKeyPrefix);
            sb.Append(".");
            sb.Append(request.Method.Name);
            sb.Append(".");

            foreach (object argument in request.Arguments)
            {
                if (argument is string && argument.ToString().Length < 50) // Preserve short string values for more readable key values
                    sb.Append((string)argument);
                else
                    sb.Append(argument.GetHashCode());

                sb.Append(".");
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
