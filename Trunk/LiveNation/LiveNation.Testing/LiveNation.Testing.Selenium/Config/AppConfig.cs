using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace LiveNation.Testing.Selenium.Config
{
	public class AppConfig : IAppConfig
	{
		public EnvironmentsConfigSection Environments
		{
			get;
			set;
		}

		public string DefaultBaseUrl
		{
			get;
			protected set;
		}

		public AppConfig()
		{
			ReadSettings();
		}

		public virtual void ReadSettings()
		{
			DefaultBaseUrl = System.Configuration.ConfigurationManager.AppSettings["defaultBaseUrl"];
			Environments = ConfigurationManager.GetSection("environments") as EnvironmentsConfigSection;
		}
	}
}