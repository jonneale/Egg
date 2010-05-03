using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class PublishingList : Entity
	{
		public virtual Site Owner
		{
			get; set;
		}

		public virtual IList<IPublishable> Content
		{
			get; protected set;
		}

		public PublishingList()
		{
			
		}

		public PublishingList(ICollection<IPublishable> list)
		{
			
		}
	}
}