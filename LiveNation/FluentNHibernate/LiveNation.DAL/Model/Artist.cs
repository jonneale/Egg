using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveNation.DAL.Model
{
	public class Artist : Content
	{
		public virtual DateTime DateOfBirth
		{
			get; set;
		}

		public virtual IList<Event> Events
		{
			get; set;
		}

		public virtual ArtistDetails Details
		{
			get; set;
		}
	}
}
