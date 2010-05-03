using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace LiveNation.Selenium.SmokeTest.AcceptanceTests
{
    [ActionSteps]
    public class Browsing_the_all_events_page_feature : BaseDefinitions
    {
        [Given]
        public void Given_a_user_lands_on_the_home_page()
        {
            selenium.Open("/");
        }

        [When]
        public void When_I_click_on_the_all_events_page()
        {
            selenium.Click("link=All Events");
            selenium.WaitForPageToLoad("30000");
        }

        [Then]
        public void Then_I_should_see_a_list_of_events()
        {
            CloserBrowserAndAssertVerifies();
        }

        [When]
        public void and_click_on_the_next_page_link()
        {
            selenium.Click("link=Next »");
            selenium.WaitForPageToLoad("30000");
        }
    }
}
