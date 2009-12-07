using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Utilities;

namespace LiveNation.Selenium.Domain.Repositories
{
    public class SeleniumTestsRepository : ISeleniumTestsRepository
    {
        private IAssemblySearch _assemblySearch;

        public SeleniumTestsRepository(IAssemblySearch assemblySearch)
        {
            _assemblySearch = assemblySearch;
        }

        public IEnumerable<ISeleniumTest> GetAll()
        {


            return new SeleniumTest[0];
        }
    }
}
