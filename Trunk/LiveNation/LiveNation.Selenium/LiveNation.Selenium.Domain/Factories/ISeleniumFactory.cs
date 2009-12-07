using System;
using Selenium;
using LiveNation.Selenium.Domain.Model;

namespace LiveNation.Selenium.Domain.Factories
{
    public interface ISeleniumFactory
    {
        ISelenium CreateInstance(BrowserClient browserClient, BrowserSetup browserSetup);
    }
}
