using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;

namespace LiveNation.Testing.AcceptanceTests.General
{
    [ActionSteps]
	public class General : SeleniumActionStepsBase
    {
		[Given("click on the \"$linkText\" link")]
		public void ClickOnLink(string linkText)
		{
			selenium.ClickAndWait(string.Format("link={0}", linkText));
		}

		[Given("typed \"$text\" into \"$textboxName\" textbox")]
		public void TypeTextIntoTextbox(string text, string textboxName)
		{
			selenium.Type(textboxName, text);
		}

		[Given("I browse to \"$url\" url")]
		public void BrowseToUrl(string url)
		{
			Selenium.Open(url);
		}
    }
}
