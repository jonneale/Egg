using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Pipeline;

namespace LiveNation.Selenium.Domain
{
    public static class ServiceLocater
    {
        public static TValue GetInstance<TValue>()
        {
            return StructureMap.ObjectFactory.GetInstance<TValue>();
        }

        public static TValue GetInstance<TValue>(object args)
        {
            args.GetType().GetProperties().ToDictionary(p => p.Name, k => k.GetValue(args, k.))
            return StructureMap.ObjectFactory.GetInstance<TValue>(new ExplicitArguments())
        }
    }
}
