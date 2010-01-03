using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace LiveNation.Testing.AcceptanceTests.Release2_3.ActionSteps
{
	[ActionSteps]
	public class events : SeleniumActionStepsBase
	{
		[When("I click on the Find tickets link at the top of the search results table")]
		public void When_I_click_on_the_Find_tickets_link_at_the_top_of_the_search_results_table()
		{
			string storedText = Selenium.GetText("css=.SearchResults .EventResults .entry-title:nth-child(1)");
			Context.SetItem("text", storedText);
			Selenium.ClickAndWait("link=Find Tickets");
		}

		[Then("I should see details about that event")]
		public void Then_I_should_see_details_about_that_event()
		{
			var storedText = Context.GetItem<string>("text");
			Assert.IsNotNullOrEmpty(storedText);
			Selenium.AssertTextPresent(storedText);
		}
	}
}