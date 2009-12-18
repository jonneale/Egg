using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

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
                x.ForRequestedType<IContainer>()
                .TheDefault.IsThis(container));

            return this;
            
        }

        public BootStrapper SetContainerOnServiceLocater(IContainer container)
        {
            ServiceLocater.SetContainer(container);
            return this;
        }
    }
}
