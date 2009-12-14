using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Config;
using System.Configuration;

namespace LiveNation.Selenium.Domain
{
	public class AppConfig : LiveNation.Selenium.Domain.IAppConfig
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
