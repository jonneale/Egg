using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace uSwitch.MvcBrownBag.Domain.NHibernate.Conventions
{
	public class HasMany : IHasManyConvention 
	{
		public void Apply(IOneToManyCollectionInstance instance)
		{
			instance.Cascade.AllDeleteOrphan();
			instance.Inverse();
		}
	}
}
