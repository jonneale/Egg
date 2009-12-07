using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facebook.Extended
{
	public class FacebookAuthenicationException : FacebookException
	{
		public FacebookAuthenicationException(string message) : base(message)
		{
		}
	}
}
