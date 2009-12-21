using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Testing.Domain.NBehave;

namespace LiveNation.Testing.NBehave
{
	public class NBehaveProcess
	{
		private IFeatureFinder _featureFinder = new FeatureFinder();
		private NBehaveConsoleProcessStart _processStarter = new NBehaveConsoleProcessStart();

		public void Run()
		{
			_processStarter.Start();
		}
	}
}
