using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class ContentRelationship : Entity
	{
		public virtual ContentBase Parent
		{
			get; set;
		}

		public virtual ContentBase Child
		{
			get; set;
		}
	}
}
