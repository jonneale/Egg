using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Model;

namespace LiveNation.Selenium.Domain
{
    public class SeleniumTest : ISeleniumTest
    {
        public string Name
        {
            get
            {
                return string.Empty;
            }
        }

        public SeleniumTest(Type testClass)
        {

        }

        public void Run()
        {

        }
    }
}
