using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace LiveNation.Testing.SmokeTests.ActionSteps
{
    [ActionSteps]
    public class globalisation : SeleniumActionStepsBase
    {
        [Given]
        public void Given_I_start_on_the_uk_home_page()
        {
        Selenium.Open("/");
}
        [When("I browse to the \"$country\" domain")]
        public void I_browse_to_the_site_name_domain(string country)
        {
            Selenium.Click("link=exact:UK: English");
            Selenium.Select("country", string.Format("label={0}", country));
            Selenium.ClickButtonWithText("Go");
        }

        [Then("I should see \"$country\" content on the page")]
        public void Then_I_should_see_country_content_on_the_page(string country)
        {
            string title = Selenium.GetTitle();
            Assert.True(title.Contains(country));
        }
    }
}
