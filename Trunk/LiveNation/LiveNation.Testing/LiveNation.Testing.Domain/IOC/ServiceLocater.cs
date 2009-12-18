using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace LiveNation.Testing.Domain.IOC
{
    public static class ServiceLocater
    {
        private static IContainer _container;

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public static IContainer GetContainer()
        {
            return _container;
        }

        public static TValue GetInstance<TValue>()
        {
            return _container.GetInstance<TValue>();
        }
    }
}
