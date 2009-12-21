using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace LiveNation.Testing.NBehave
{
	public class NBehaveConsoleProcessStart
	{
		private Assembly _assemblies;
		private IEnumerable<string> _featureFilePaths;

		public NBehaveConsoleProcessStart(Assembly assemblies, IEnumerable<string> featureFilePaths)
		{
			_assemblies = assemblies;
			_featureFilePaths = featureFilePaths;
		}

		public void Start()
		{
			

			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = "nbehave-console.exe",
				RedirectStandardOutput = true,
				UseShellExecute = false
			};

			process.Start();
		}
	}
}
