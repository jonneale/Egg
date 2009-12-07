using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain;
using NUnit.Framework;

namespace LiveNation.Selenium.SmokeTest
{
	public class Search : SeleniumTestFixture
	{
		[Test]
		public void Search_for_artist_called_clutch_from_homepage()
		{
			selenium.Open("/");
			selenium.Type("q", "clutch");
			selenium.Select("refine", "label=Artists");
			selenium.Click("masterSearch");
			selenium.WaitForPageToLoad("30000");
			try
			{
				Assert.IsTrue(selenium.IsTextPresent("Artist Matches"));
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
			}
			Assert.AreEqual("clutch Search results | Live Nation UK", selenium.GetTitle());
			try
			{
				Assert.IsTrue(selenium.IsTextPresent("Search Results for \"clutch\""));
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
			}
			try
			{
				Assert.IsTrue(selenium.IsElementPresent("link=Clutch"));
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
			}
			selenium.Click("link=Clutch");
		}
	}
}
