using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.MvcBrownBag.Domain
{
	public abstract class Entity
	{
		public virtual int Id
		{
			get; protected set;
		}
	}
}
