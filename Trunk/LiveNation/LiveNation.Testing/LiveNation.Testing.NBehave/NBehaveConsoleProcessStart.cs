using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using LiveNation.Testing.Domain.Framework;
using StructureMap;

namespace LiveNation.Testing.NBehave
{
	public class NBehaveConsoleProcessStart
	{
        private const string _filePath = "nbehave-console.exe";
	    private readonly IContainer _container;
        private IEnumerable<Assembly> _assemblies;
		private IEnumerable<string> _featureFilePaths;

		public NBehaveConsoleProcessStart(IContainer container, IEnumerable<Assembly> assemblies, IEnumerable<string> featureFilePaths)
		{
		    _container = container;
		    _assemblies = assemblies;
			_featureFilePaths = featureFilePaths;
		}

		public void Start()
		{
		    string dllsString = GetDllsCommandArgument();
		    string featuresCommandArg = GetFeaturePathsCommandArgument();

            Console.WriteLine(_filePath);
            Console.WriteLine(dllsString);
            Console.WriteLine(featuresCommandArg);

		    var process = _container.GetInstance<IProcess>();

			process.StartInfo = new ProcessStartInfo
			{
                FileName = _filePath,
                Arguments = string.Empty,
				RedirectStandardOutput = true,
				UseShellExecute = false
			};

			process.Start();
		}

        private string GetArgumentString()
        {
            return string.Concat(GetDllsCommandArgument(), " ", GetFeaturePathsCommandArgument());
        }

	    private string GetDllsCommandArgument()
	    {
	        var dllPaths = _assemblies.Select(x => x.Location);
	        return string.Join(" ", dllPaths.ToArray());
	    }

        private string GetFeaturePathsCommandArgument()
        {
            return string.Concat("/sf=", string.Join(";", _featureFilePaths.ToArray()));
        }
	}
}
