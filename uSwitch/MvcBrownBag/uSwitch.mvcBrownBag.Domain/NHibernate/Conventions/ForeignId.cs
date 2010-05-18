using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;

namespace uSwitch.MvcBrownBag.Domain.NHibernate.Conventions
{
	public class ForeignId : FluentNHibernate.Conventions.ForeignKeyConvention
	{
		protected override string GetKeyName(Member property, Type type)
		{
			if (property == null)
			{
				return type.Name + "ID"; // many-to-many, one-to-many, join
			}

			return property.Name + "ID"; // many-to-one
		}
	}
}
