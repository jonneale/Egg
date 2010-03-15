using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class PublishingList : Entity
	{
		public virtual ICollection<ContentBase> Content
		{
			get; set;
		}
	}
}