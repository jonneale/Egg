using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveNation.DAL.Model
{
	public abstract class Content
	{
		public virtual int Id
		{
			get;
			protected set;
		}

		public virtual string Name
		{
			get; set;
		}
	}
}
