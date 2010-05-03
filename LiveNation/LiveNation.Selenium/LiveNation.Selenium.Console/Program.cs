using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Repositories;
using LiveNation.Selenium.Domain;

namespace LiveNation.Selenium.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BootStapper.Configure();

            var repository = ServiceLocater.GetInstance<ISeleniumTestsRepository>();
            IEnumerable<ISeleniumTest> tests = repository.GetAll();

            foreach (ISeleniumTest test in tests)
            {
                test.Run();
            }
        }
    }
}
