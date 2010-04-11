using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace uSwitch.Content.Domain.Persistance.Nhibernate.Conventions
{
	public class ToManyConvention : IHasManyConvention
	{
		public void Apply(IOneToManyCollectionInstance instance)
		{
			instance.LazyLoad();
			instance.Cascade.AllDeleteOrphan();
			instance.Inverse();
		}
	}
}
