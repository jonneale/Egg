using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Common.Commands
{
	public class AddContentCommand : ICommand
	{
		public string Name { get; set; }
		public string ContentType { get; set; }
		public IDictionary<string, string> Properties { get; set; }
		public string Path { get; set; }
	}
}