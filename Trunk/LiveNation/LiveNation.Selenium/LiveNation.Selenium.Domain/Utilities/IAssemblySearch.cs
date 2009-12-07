using System;
namespace LiveNation.Selenium.Domain.Utilities
{
    public interface IAssemblySearch
    {
        System.Collections.Generic.IEnumerable<Type> GetAllClassesWithAttribute(Type attribute);
    }
}
