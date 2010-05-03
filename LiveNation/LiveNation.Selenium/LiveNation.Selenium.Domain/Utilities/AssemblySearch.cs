using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LiveNation.Selenium.Domain.Utilities
{
    public class AssemblySearch : LiveNation.Selenium.Domain.Utilities.IAssemblySearch
    {
        private Assembly _assembly;

        public AssemblySearch(Assembly assembly) 
        {
            _assembly = assembly;
        }

        public IEnumerable<Type> GetAllClassesWithAttribute(Type attribute)
        {
            IEnumerable<Type> types = _assembly.GetTypes().Where(x => 
                x.GetCustomAttributes(true)
                .Any(a => a.GetType().IsSubclassOf(attribute)));

            return types;
        }
    }
}
