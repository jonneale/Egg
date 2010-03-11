using System;

namespace uSwitch.Content.Domain.Templates
{
	public class ResourceNameAttribute : Attribute
	{
		public string ExtensionName
		{
			get; set;
		}
	}
}