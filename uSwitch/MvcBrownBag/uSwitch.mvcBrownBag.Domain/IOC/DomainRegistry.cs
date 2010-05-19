using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using uSwitch.MvcBrownBag.Domain.Repository;

namespace uSwitch.MvcBrownBag.Domain.IOC
{
	public class DomainRegistry : Registry
	{
		public DomainRegistry()
		{
			Scan(x =>
			     	{
			     		x.AssemblyContainingType<Repository.Repository>();
			     		x.WithDefaultConventions();
			     	});
		}
	}
}
