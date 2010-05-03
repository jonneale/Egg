using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Testing.Selenium.Model;
using Selenium;

namespace LiveNation.Testing.Selenium.Factories
{
	public class SeleniumFactory : ISeleniumFactory
	{
		public ISelenium CreateInstance(BrowserClient browserClient, BrowserSetup browserSetup)
		{
			ISelenium selenium = new DefaultSelenium(browserClient.Address
			                                         , browserClient.Port
			                                         , browserSetup.Profile
			                                         , browserSetup.BaseUrl.ToString());

			return selenium;
		}
	}
}