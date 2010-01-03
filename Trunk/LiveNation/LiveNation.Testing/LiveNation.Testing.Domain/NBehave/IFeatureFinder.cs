using System;
namespace LiveNation.Testing.Domain.NBehave
{
	public interface IFeatureFinder
	{
		System.Collections.Generic.IEnumerable<string> Find(string directory);
		string FindSingle(string directory, string fileName);
	}
}
