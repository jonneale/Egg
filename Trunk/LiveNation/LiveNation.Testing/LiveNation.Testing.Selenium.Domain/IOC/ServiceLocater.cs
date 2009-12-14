using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveNation.Selenium.Domain
{
    public static class ServiceLocater
    {
        public static TValue GetInstance<TValue>()
        {
            return StructureMap.ObjectFactory.GetInstance<TValue>();
        }
    }
}
