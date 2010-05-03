using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Conventions.Instances;

namespace uSwitch.Content.Domain.Persistance.Nhibernate.Conventions
{
	public class IdentityConvention : FluentNHibernate.Conventions.IIdConvention
	{
		public void Apply(IIdentityInstance instance)
		{
			instance.Column("Id");
		}
	}

	public class ForeignIdConvention : FluentNHibernate.Conventions.ForeignKeyConvention
	{
		protected override string GetKeyName(Member property, Type type)
		{
			throw new NotImplementedException();
		}
	}
}
