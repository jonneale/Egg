using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class ContentPropertyAttribute : Attribute
	{
		public string Name
		{
			get; set;
		}
	}
}
