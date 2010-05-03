using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace uSwitch.Content.Domain.Templates
{
	public class EmbeddedResourceTemplate : ITemplate
	{
		protected virtual string GetResourceName()
		{
			string fileExtension = string.Empty;

			var customerAttributes = GetType().GetCustomAttributes(typeof (ResourceNameAttribute), true);
			if (customerAttributes.Count() > 0)
			{
				fileExtension = "." + ((ResourceNameAttribute)customerAttributes.First()).ExtensionName;
			}

			return string.Concat(GetType().FullName, fileExtension);
		}

		private Assembly GetTypeAssembly()
		{
			return GetType().Assembly;
		}

		public Stream GetSource()
		{
			return GetTypeAssembly().GetManifestResourceStream(GetResourceName());
		}
	}
}
