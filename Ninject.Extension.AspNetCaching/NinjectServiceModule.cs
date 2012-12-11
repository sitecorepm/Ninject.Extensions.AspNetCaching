using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninject.Extension.AspNetCache
{
    public class NinjectServiceModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICacheManager>().ToMethod(delegate(Ninject.Activation.IContext context)
            {
                return new ServiceDataCache(10.0);
            }).InSingletonScope();
        }
    }
}
