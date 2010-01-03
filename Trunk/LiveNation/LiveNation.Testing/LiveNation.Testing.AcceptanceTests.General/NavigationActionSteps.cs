using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;

namespace LiveNation.Testing.AcceptanceTests.General
{
	[ActionSteps]
	public class NavigationActionSteps : SeleniumActionStepsBase
	{
		[Given("a user browse's to the \"$pageName\" page")]
		[Given("I browse to the \"$pageName\" page")]
		public void BrowserToPage(string pageName)
		{
			Selenium.NavigateToPage(pageName);
		}
	}
}
