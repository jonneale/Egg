using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain;
using LiveNation.Selenium.Domain.Utilities;
using NUnit.Framework;

namespace LiveNation.Selenium.SmokeTest
{
	public class All_events : SeleniumTestFixture
	{
		[Test]
		public void Browsing_all_events_section_of_website()
		{
            selenium.DeleteAllVisibleCookies();

			selenium.Open("/");
			selenium.Click("link=All Events");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("link=Next »");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("//div[@id='mainContent']/div/div/div/div[2]/div/a[8]");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("link=« First");
			selenium.WaitForPageToLoad("30000");
			selenium.Click("link=Event");
			selenium.WaitForPageToLoad("30000");
		}
	}
}
