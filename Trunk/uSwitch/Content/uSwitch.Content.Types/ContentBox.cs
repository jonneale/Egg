using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uSwitch.Content.Domain;
using uSwitch.Content.Domain.Attributes;

namespace uSwitch.Content.Types
{
	[HasTemplate(TemplateType = typeof(Templates.ContentBox))]
	public class ContentBox : ContentBase
	{
		[ContentProperty]
		public string HeaderText
		{
			get; set;
		}

		[ContentProperty]
		public string Body
		{
			get; set;
		}
	}
}
