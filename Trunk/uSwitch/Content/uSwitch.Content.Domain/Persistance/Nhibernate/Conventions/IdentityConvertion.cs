using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions.Instances;

namespace uSwitch.Content.Domain.Persistance.Nhibernate.Conventions
{
	public class IdentityConvertion : FluentNHibernate.Conventions.IIdConvention
	{
		public void Apply(IIdentityInstance instance)
		{
			instance.Column("Id");
		}
	}
}
