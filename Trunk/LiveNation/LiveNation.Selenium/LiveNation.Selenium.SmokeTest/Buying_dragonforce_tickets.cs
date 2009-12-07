using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using LiveNation.Selenium.Domain;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    public class Buying_dragonforce_tickets : SeleniumTestFixture
	{
		[Test]
		public void TheUntitled2Test()
		{
            selenium.Open("/");
            selenium.Click("link=Dragonforce Tickets");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("link=Find Tickets");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("//div[@id='artist_ticket_info']/div[2]/div[2]/span/a/span");
            selenium.WaitForPageToLoad("30000");
            try
            {
                Assert.IsTrue(selenium.IsTextPresent("Dragoforce"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
				SaveScreenShot();
            }
            Assert.AreEqual("Thu 19 Nov 2009, 19:00", selenium.GetText("artist_event_date"));
		}
	}
}
