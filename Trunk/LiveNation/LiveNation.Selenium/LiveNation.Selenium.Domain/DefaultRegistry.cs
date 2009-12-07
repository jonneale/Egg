using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Factories;
using LiveNation.Selenium.Domain.Repositories;
using LiveNation.Selenium.Domain.Utilities;
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
                    .TheDefault.Is.OfConcreteType<SeleniumFactory>();

            ForRequestedType<IAssemblySearch>()
                    .TheDefault.Is.OfConcreteType<AssemblySearch>();

			ForRequestedType<IAppConfig>()
					.TheDefault.Is.OfConcreteType<AppConfig>();
        }
    }
}
