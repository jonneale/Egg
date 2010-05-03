using System;
using LiveNation.Testing.Selenium.Model;
using Selenium;

namespace LiveNation.Testing.Selenium.Factories
{
	public interface ISeleniumFactory
	{
		ISelenium CreateInstance(BrowserClient browserClient, BrowserSetup browserSetup);
	}
}