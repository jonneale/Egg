using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace uSwitch.Content.Domain.Templates
{
	public interface ITemplate
	{
		Stream GetSource();
	}
}
