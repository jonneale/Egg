using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Facebook.Extended
{
	public interface INotification
	{
		StringCollection UserIds { get; }
		string EmailMarkup { get; }
		string BodyMarkup { get; }
	}
}
