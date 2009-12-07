using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicSmapleApp
{
	public static class DynamicExtensions
	{
		public static dynamic GetExpando(this object instance)
		{
			dynamic dynamicObject = new ExpandoExtension(instance);
			return dynamicObject;
		}
	}
}
