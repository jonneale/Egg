using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Repositories;
using LiveNation.Selenium.Domain.Utilities;
using StructureMap;

namespace LiveNation.Selenium.Domain
{
    public static class BootStapper
    {
        public static void Configure()
        {
            ObjectFactory.Initialize(i => i.AddRegistry(new DefaultRegistry()));
        }
    }
}
