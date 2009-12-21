using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace LiveNation.Testing.Release.v2_3.AcceptanceTests.ActionSteps
{
    [ActionSteps]
	public class my_LiveNation : BaseDefinitions
    {
        [When]
        public void When_I_click_the_My_Live_Nation()
        {
			selenium.Click("link=My Live Nation");
			selenium.WaitForPageToLoad("30000");
        }

        [Then]
        public void Then_I_should_see_the_My_Live_Nation_page()
        {
			try
			{
				Assert.IsTrue(selenium.IsTextPresent("Welcome to My Live Nation"));
			}
			catch (AssertionException e)
			{
				verificationErrors.Append(e.Message);
			}
        }
    }
}
