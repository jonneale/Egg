using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class ContentPropertyValue : Entity
	{
		public virtual string GetPropertyAsString()
		{
			return string.Empty;
		}

		public string Name
		{
			get; set;
		}

		public virtual string PropertyValue
		{
			get; set;
		}
	}
}
