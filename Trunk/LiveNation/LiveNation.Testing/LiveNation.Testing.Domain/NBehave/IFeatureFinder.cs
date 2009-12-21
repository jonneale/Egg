using System;
namespace LiveNation.Testing.Domain.NBehave
{
	public interface IFeatureFinder
	{
		System.Collections.Generic.IEnumerable<string> Find(string directory);
	}
}
