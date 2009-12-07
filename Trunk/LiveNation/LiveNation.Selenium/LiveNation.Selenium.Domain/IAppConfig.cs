using System;
namespace LiveNation.Selenium.Domain
{
	public interface IAppConfig
	{
		string DefaultBaseUrl { get; }
		void ReadSettings();
	}
}
