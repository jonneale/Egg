using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Factories;
using LiveNation.Selenium.Domain.Repositories;
using LiveNation.Selenium.Domain.Utilities;
using Selenium;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;

namespace LiveNation.Selenium.Domain
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            ForRequestedType<ISeleniumTestsRepository>()
                    .TheDefault.Is.OfConcreteType<SeleniumTestsRepository>();

            ForRequestedType<ISeleniumFactory>()
                    .CacheBy(InstanceScope.Singleton)
                    .TheDefault.Is.OfConcreteType<SeleniumFactory>();

            ForRequestedType<ISelenium>()
                    .CacheBy(InstanceScope.ThreadLocal)
                    .TheDefault.Is.OfConcreteType<DefaultSelenium>();

            ForRequestedType<IAssemblySearch>()
                    .TheDefault.Is.OfConcreteType<AssemblySearch>();

			ForRequestedType<IAppConfig>()
                    .CacheBy(InstanceScope.Singleton)
					.TheDefault.Is.OfConcreteType<AppConfig>();
        }
    }
}
