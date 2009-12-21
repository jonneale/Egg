using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LiveNation.Testing.Domain.NBehave
{
	public class ActionStepAssemblyFinder : LiveNation.Testing.Domain.NBehave.IActionStepAssemblyFinder
	{
		public IEnumerable<Assembly> Find(string directoryPath)
		{
			return null;
		}
	}
}
