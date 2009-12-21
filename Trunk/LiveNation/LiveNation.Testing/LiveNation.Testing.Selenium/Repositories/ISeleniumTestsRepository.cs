using System;
using System.Collections.Generic;
namespace LiveNation.Selenium.Domain.Repositories
{
    public interface ISeleniumTestsRepository
    {
        IEnumerable<ISeleniumTest> GetAll();
    }
}
