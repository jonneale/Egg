using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;

namespace LiveNation.Testing.Release.v2_3.AcceptanceTests.ActionSteps
{
	[ActionSteps]
	public class homepage : SeleniumActionStepsBase
	{
		[Then("I should see a list of links in the content box")]
		public void Then_I_should_see_a_list_of_links_in_the_content_box()
		{
			Selenium.AssertElementPresent("css=#concert-tickets");
		}

		[Then("each one should be clickable")]
		public void And_each_one_should_be_clickable()
		{
			string originalLocation = Selenium.GetLocation();
			Func<int, string> locator = currentCount => string.Format(@"//*[@id=""concert-tickets""]//li[{0}]/a", currentCount);

			var counter = 1;
			var elementFound = true;
			do
			{
				try
				{
					Selenium.AssertElementPresent(locator(counter));
				}
				catch
				{
					elementFound = false;
				}

				if (elementFound)
				{
					Selenium.ClickAndWait(locator(counter));
					Selenium.OpenAndWait(originalLocation);
				}

				counter++;
			} while (elementFound);
		}

		[Then("I should see the Hero player")]
		public void Then_I_should_see_the_Hero_player()
		{
			Selenium.AssertElementPresent("css=#heroPlayerv23");
		}
	}
}
