using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LiveNation.Testing.Domain.NBehave;
using StructureMap;

namespace LiveNation.Testing.NBehave
{
	public class NBehaveProcess
	{
	    private readonly IFeatureFinder _featureFinder;
	    private readonly IActionStepAssemblyFinder _actionStepAssemblyFinder;
	    private readonly IContainer _container;

	    public NBehaveProcess(IContainer container, IFeatureFinder featureFinder, IActionStepAssemblyFinder actionStepAssemblyFinder)
	    {
	        _container = container;
	        _featureFinder = featureFinder;
	        _actionStepAssemblyFinder = actionStepAssemblyFinder;
	    }

	    public void Run(string workingDirectory, string[] commandArgs)
		{
            var assemblies = _actionStepAssemblyFinder.Find(workingDirectory);
			var featurePaths = GetFeaturePaths(workingDirectory, commandArgs);

            var nbehaveConsole = new NBehaveConsoleProcessStart(_container, assemblies, featurePaths);
            nbehaveConsole.Start();
		}

		private IEnumerable<string> GetFeaturePaths(string workingDirectory, string[] commandArgs)
		{
			if (commandArgs.Length > 0)
			{
				return new[] { _featureFinder.FindSingle(workingDirectory, commandArgs[0]) };
			}

			return _featureFinder.Find(workingDirectory);
		}
	}
}
