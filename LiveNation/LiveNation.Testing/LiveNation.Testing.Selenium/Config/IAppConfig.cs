using System;

namespace LiveNation.Testing.Selenium.Config
{
	public interface IAppConfig
	{
		string DefaultBaseUrl { get; }
		void ReadSettings();
	}
}