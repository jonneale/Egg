using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain.ContentTypes
{
	public interface IWantToSerializeProperties
	{
		Stream Serialize();
	}
}
