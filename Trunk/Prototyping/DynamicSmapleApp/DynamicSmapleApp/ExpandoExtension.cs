using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace DynamicSmapleApp
{
	public class ExpandoExtension : ExtendedDynamicObject
	{
		private dynamic _instance;
		private IDictionary<string, dynamic> _members = new Dictionary<string, dynamic>();
		
		public ExpandoExtension(object instance)
		{
			_instance = instance;
		}
	}
}
