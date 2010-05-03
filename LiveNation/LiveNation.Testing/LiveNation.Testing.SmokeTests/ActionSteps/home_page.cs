using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;

namespace LiveNation.Testing.SmokeTests.ActionSteps
{
    [ActionSteps]
    public class home_page : SeleniumActionStepsBase
    {
        [Then("I should see a list of links in the \"Concent Tickets\" content box")]
        public void Then_I_should_see_a_list_of_links_in_the_content_box()
        {
            Selenium.AssertElementPresent("css=#concert-tickets");
        }

		[Then("I should see a list of links in the \"On Sale Now\" content box")]
		public void Then_I_should_see_a_list_of_links_in_the_on_sale_now()
		{
			Selenium.AssertElementPresent("css=#concert-tickets");
		}

		[Then("each one of the concent ticket links should be clickable")]
        public void Each_one_should_be_clickable()
		{
			CycleThroughLinksAndClick(@"//*[@id=""concert-tickets""]//li[{0}]/a");
		}

    	[Then("each one of the on sale now links should be clickable")]
		public void Each_one_of_the_on_sale_now_links_should_be_clickable()
		{
			CycleThroughLinksAndClick(@"//*[@id=""tabs""]//ul[@class=""tabsBody""]/li[{0}]/div[@class=""tickets""]/a");
		}

		private void CycleThroughLinksAndClick(string cssClass)
		{
			string originalLocation = Selenium.GetLocation();
			Func<int, string> locator = currentCount => string.Format(cssClass, currentCount);

			var counter = 1;
			var elementFound = true;
			do
			{
				elementFound = Selenium.IsElementPresent(locator(counter));

				if (elementFound)
				{
					Selenium.ClickAndWait(locator(counter));
					Selenium.OpenAndWait(originalLocation);
				}

				counter++;
			} while (elementFound);
		}
    }
}
