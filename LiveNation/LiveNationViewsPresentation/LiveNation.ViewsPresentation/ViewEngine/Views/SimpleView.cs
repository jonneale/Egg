using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.IO;

namespace LiveNation.ViewsPresentation.ViewEngine.Views
{
	public class SimpleView : IView
	{
		private string _viewPhysicalPath;

		public SimpleView(string viewPhysicalPath)
		{
			_viewPhysicalPath = viewPhysicalPath;
		}

		public void Render(ViewContext viewContext, TextWriter writer)
		{
			string rawContents = File.ReadAllText(_viewPhysicalPath);
			string parsedContents = Parse(rawContents, viewContext.ViewData);

			writer.Write(parsedContents);
		}

		public string Parse(string contents, ViewDataDictionary viewData)
		{
			return Regex.Replace(contents, "\\{(.+)\\}", m => GetMatch(m, viewData));
		}

		protected virtual string GetMatch(Match m, ViewDataDictionary viewData)
		{
			if (m.Success)
			{
				string key = m.Result("$1");
				if (viewData.ContainsKey(key))
				{
					return viewData[key].ToString();
				}
			}
			return string.Empty;
		}
	}
}
