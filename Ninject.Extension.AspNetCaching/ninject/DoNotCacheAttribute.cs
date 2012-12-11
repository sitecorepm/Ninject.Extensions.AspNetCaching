using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Extensions.Interception.Attributes;

namespace Ninject.Extension.AspNetCache
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DoNotCacheAttribute : DoNotInterceptAttribute
    {
    }
}
