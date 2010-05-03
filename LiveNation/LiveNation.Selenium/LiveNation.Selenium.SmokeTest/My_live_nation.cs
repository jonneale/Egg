using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LiveNation.Selenium.Domain;
using LiveNation.Selenium.Domain.Utilities;
using NUnit.Framework;

namespace LiveNation.Selenium.SmokeTest
{
	public class My_live_nation : SeleniumTestFixture
	{
        [Test]
		public void Login_to_my_live_nation_account()
		{
			selenium.Open("/");
            selenium.ClearBrowserSession();
            selenium.Open("/");
			selenium.Click("link=My Live Nation");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (selenium.IsElementPresent("email")) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
			selenium.Type("email", "Jwilliamson@gmail.com");
			selenium.Type("password", "noivilbo");
			selenium.Click("//input[@value='Sign In']");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (selenium.IsElementPresent("link=Sign Out")) 
                        break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
			selenium.Click("link=My Live Nation");
			selenium.WaitForPageToLoad("30000");
			Assert.AreEqual("My Live Nation", selenium.GetTitle());
            //try
            //{
            //    Assert.IsTrue(selenium.IsTextPresent("Welcome James to My Live Nation!"));
            //}
            //catch (AssertionException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
		}
	}
}
