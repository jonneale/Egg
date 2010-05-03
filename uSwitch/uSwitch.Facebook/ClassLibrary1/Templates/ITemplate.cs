using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facebook.Extended.Templates
{
	public interface ITemplate
	{
		Int64 Id
		{
			get;
		}

		string JsonData
		{ 
			get;
		}
	}
}
