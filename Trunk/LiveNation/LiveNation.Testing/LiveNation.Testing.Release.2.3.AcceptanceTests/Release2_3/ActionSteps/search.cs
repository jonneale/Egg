using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace LiveNation.Testing.Release.v2_3.AcceptanceTests.ActionSteps
{
	[ActionSteps]
	public class search : SeleniumActionStepsBase
	{
		[When("I type \"$text\" into the search box")]
		public void When_I_type_text_into_the_search_box(string text)
		{
			Selenium.Type("q", text);
		}

		[When("I click on the search button")]
		public void When_click_on_the_search_button()
		{
			Selenium.ClickAndWait("masterSearch");
		}

		[Then("I should see search results for \"$artist\"")]
		public void Then_I_should_see_search_results_for_artist(string artist)
		{
			Selenium.AssertElementPresent("link=Madonna");
		}
	}
}
