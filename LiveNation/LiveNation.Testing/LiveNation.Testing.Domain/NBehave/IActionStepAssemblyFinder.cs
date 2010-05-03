using System;
namespace LiveNation.Testing.Domain.NBehave
{
	public interface IActionStepAssemblyFinder
	{
		System.Collections.Generic.IEnumerable<System.Reflection.Assembly> Find(string directoryPath);
	}
}
