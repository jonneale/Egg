using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uSwitch.MvcBrownBag.Domain;

namespace uSwitch.MvcBrownBag.Domain
{
	public class Artist : Entity
	{
		public Artist()
		{
		}

		public Artist(string name, string bandName)
		{
			Name = name;
			BandName = bandName;
		}

		public virtual string Name
		{
			get; set;
		}

		public virtual string BandName
		{
			get;
			set;
		}

		public virtual ICollection<EventLineUp> LineUp
		{
			get;
			set;
		}
	}
}
