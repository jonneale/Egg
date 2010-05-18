using System;
using System.Collections.Generic;

namespace uSwitch.MvcBrownBag.Domain
{
	public class Event : Entity
	{
		public virtual string Name
		{
			get; set;
		}

		public virtual DateTime ShowTime
		{
			get; set;
		}

		public virtual ICollection<EventLineUp> EventLineUps
		{
			get; set;
		}
	}
}