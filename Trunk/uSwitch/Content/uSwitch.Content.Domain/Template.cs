using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class Template
	{
		public virtual string Name
		{
			get; set;
		}

		public virtual string Source
		{
			get; set;
		}

		public virtual string GetSource()
		{
			return Source;
		}
	}
}
