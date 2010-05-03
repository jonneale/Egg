using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facebook.Extended.Templates
{
	public abstract class BaseTemplate : ITemplate
	{
		public abstract Int64 Id
		{ 
			get;
		}

		public abstract string JsonData
		{
			get;
		}
	}
}
