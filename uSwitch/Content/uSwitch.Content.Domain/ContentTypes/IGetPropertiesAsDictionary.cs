using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain.ContentTypes
{
	public interface IGetPropertiesAsDictionary
	{
		IDictionary<string, object> GetDictionary();
	}
}
