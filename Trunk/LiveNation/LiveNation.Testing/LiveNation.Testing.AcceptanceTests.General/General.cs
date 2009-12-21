using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using NBehave.Narrator.Framework;

namespace LiveNation.Testing.AcceptanceTests.General
{
    [ActionSteps]
	public class General : BaseDefinitions
    {
		[Given]
		public void Given_I_browse_to_LiveNation_home_page()
		{
			selenium.Open("/");
		}

		[Given("I browse to \"$url\"")]
		public void Given_I_browse_to(string url)
		{
			selenium.Open(url);
		}
    }
}
