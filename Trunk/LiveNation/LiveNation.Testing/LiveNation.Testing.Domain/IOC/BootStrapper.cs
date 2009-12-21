using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using LiveNation.Testing.Domain.NBehave;

namespace LiveNation.Testing.Domain.IOC
{
    public class BootStrapper
    {
        public BootStrapper Configure()
        {
            return Configure(new Container());
        }

        public BootStrapper Configure(IContainer container)
        {
			container.Configure(x =>
			{
				x.ForRequestedType<IContainer>()
					.TheDefault.IsThis(container);

			    x.ForRequestedType<IFeatureFinder>()
			        .TheDefaultIsConcreteType<FeatureFinder>();

                x.ForRequestedType<IActionStepAssemblyFinder>()
                    .TheDefaultIsConcreteType<ActionStepAssemblyFinder>();
			});

            SetContainerOnServiceLocater(container);

            return this;
        }

        public BootStrapper SetContainerOnServiceLocater(IContainer container)
        {
            ServiceLocater.SetContainer(container);
            return this;
        }
    }
}
