using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninject.Extension.AspNetCache
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheTimeoutAttribute : Attribute
    {
        public int TimeoutMinutes { get; set; }
    }
}
