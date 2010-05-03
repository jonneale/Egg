using System;

namespace uSwitch.Content.Domain.Attributes
{
	public class HasTemplateAttribute : Attribute
	{
		public Type TemplateType
		{
			get; set;
		}
	}
}