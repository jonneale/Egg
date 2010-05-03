using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveNation.DAL.Model
{
	public class Event : Content
	{
		public virtual DateTime DateOfEvent
		{
			get;
			set;
		}

		public virtual IList<Artist> Artists
		{
			get; set;
		}
	}
}
