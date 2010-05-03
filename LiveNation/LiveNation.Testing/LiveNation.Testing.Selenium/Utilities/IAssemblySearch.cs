using System;

namespace LiveNation.Testing.Selenium.Utilities
{
	public interface IAssemblySearch
	{
		System.Collections.Generic.IEnumerable<Type> GetAllClassesWithAttribute(Type attribute);
	}
}