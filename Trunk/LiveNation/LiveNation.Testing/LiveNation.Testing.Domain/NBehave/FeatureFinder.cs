using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LiveNation.Testing.Domain.NBehave
{
	public class FeatureFinder : LiveNation.Testing.Domain.NBehave.IFeatureFinder
	{
		private readonly IList<string> _extensions;

		public FeatureFinder()
		{
			_extensions = new[] { "feature" };
		}

		protected FeatureFinder(IEnumerable<string> extensions)
		{
            _extensions = extensions.ToList();
		}

		public IEnumerable<string> Find(string directory)
		{
            string[] filePaths = Directory.GetFiles(directory, string.Format("*.{0}", _extensions.First()), SearchOption.AllDirectories);
			return filePaths;
		}
	}
}
