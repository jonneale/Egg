using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NBehave.Narrator.Framework;

namespace LiveNation.Testing.Domain.NBehave
{
	public class ActionStepAssemblyFinder : IActionStepAssemblyFinder
	{
		public IEnumerable<Assembly> Find(string directoryPath)
		{
		    IEnumerable<string> dllPaths = Directory.GetFiles(directoryPath, "*.dll", SearchOption.AllDirectories);
            IEnumerable<Assembly> assemblies = GetActionStepAssemblies(dllPaths).ToList();
		    return assemblies;
		}

        private static IEnumerable<Assembly> GetActionStepAssemblies(IEnumerable<string> dllPaths)
	    {
	        foreach (var path in dllPaths)
	        {
	            Assembly assembly = Assembly.LoadFile(path);
	            if (assembly.GetTypes().Any(x =>
                                        x.GetCustomAttributes(true)
                                        .Any(a => a.GetType()
                                            .Equals(typeof(ActionStepsAttribute)))))
	            {
	                yield return assembly;
	            }
	        }
	    }
	}
}
