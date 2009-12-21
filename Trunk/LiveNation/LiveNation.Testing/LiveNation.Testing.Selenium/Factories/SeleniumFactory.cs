using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using LiveNation.Selenium.Domain.Model;

namespace LiveNation.Selenium.Domain.Factories
{
    public class SeleniumFactory : ISeleniumFactory
    {
        public ISelenium CreateInstance(BrowserClient browserClient, BrowserSetup browserSetup)
        {
            ISelenium selenium = new DefaultSelenium(browserClient.Address
                , browserClient.Port
                , browserSetup.Profile
                , browserSetup.BaseUrl.ToString());

            return selenium;
        }
    }
}
